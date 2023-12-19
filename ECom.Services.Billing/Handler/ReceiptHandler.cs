using AutoMapper;
using Dto.OrderDto;
using Dto.ReceiptDto;
using Dto.ReceiptDto;
using ECom.Services.Billing.Data;
using ECom.Services.Billing.Models;
using ECom.Services.Sales.Utility;
using Messages;
using Messages.ProductMessages;
using Messages.ReceiptMessages;
using NServiceBus.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECom.Services.Billing.Handler
{
    public class ReceiptHandler : 
        IHandleMessages<GetReceiptByStatus>,
        IHandleMessages<PaidReceipt>,
        IHandleMessages<CreateReceipt>
    {
        private IMapper mapper;
        static ILog log = LogManager.GetLogger<ReceiptHandler>();

        public ReceiptHandler()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
            });
            this.mapper = config.CreateMapper();
        }

        public async Task Handle(GetReceiptByStatus message, IMessageHandlerContext context)
        {
            log.Info("Received message");
            var responseMessage = new Response<ReceiptDto>();
            try
            {
                List<Receipt> receipts = DataAccess.Ins.DB.Receipts.Where(u => u.Status.Equals(message.Status)).OrderBy(u => u.Id).ToList();
                responseMessage.responseData = receipts.Select(
                    emp => mapper.Map<ReceiptDto>(emp)
                    );
                responseMessage.ErrorCode = 200;
                log.Info("Response sent");
            }
            catch
            {
                log.Info("Something went wrong");
                responseMessage.ErrorCode = 500;
            }
            await context.Reply(responseMessage).ConfigureAwait(false);
        }

        public async Task Handle(PaidReceipt message, IMessageHandlerContext context)
        {
            log.Info("Received message");
            var responseMessage = new Response<ReceiptDto>();

            if (message.ReceiptId == 0)
            {
                responseMessage.ErrorCode = 400;
            }
            else
            {
                try
                {
                    Receipt receipt = DataAccess.Ins.DB.Receipts.Where(u => u.Id == message.ReceiptId).First();
                    receipt.Status = '1';
                    DataAccess.Ins.DB.SaveChanges();
                    responseMessage.ErrorCode = 200;
                    log.Info("Response sent");

                    var publishMessage = new ReceiptPaid() { PaidDate = DateOnly.FromDateTime(DateTime.Now), Income = receipt.Cost };
                    context.Publish(publishMessage).ConfigureAwait(false);
                }
                catch
                {
                    log.Info("Something went wrong");
                    responseMessage.ErrorCode = 500;
                }
            }
            await context.Reply(responseMessage).ConfigureAwait(false);
        }

        public async Task Handle(CreateReceipt message, IMessageHandlerContext context)
        {
            var responseMessage = new Response<ReceiptDto>();
            if (message.newReceipt == null)
            {
                log.Error("BadRequest, missing product info");
                responseMessage.ErrorCode = 403;
            }
            else
            {
                Receipt newReceipt = mapper.Map<Receipt>(message.newReceipt);
                try
                {
                    log.Info("Adding new Receipt");
                    DataAccess.Ins.DB.Receipts.Add(newReceipt);

                    DataAccess.Ins.DB.SaveChanges();


                    log.Info("Receipt added");
                    responseMessage.ErrorCode = 200;
                }
                catch (Exception ex)
                {
                    log.Error($"Error: {ex}");
                    responseMessage.ErrorCode = 500;
                }
            }
            await context.Reply(responseMessage).ConfigureAwait(false);
        }
    }
}
