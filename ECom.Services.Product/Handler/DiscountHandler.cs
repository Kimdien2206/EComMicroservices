using AutoMapper;
using Dto.ProductDto;
using ECom.Services.Products.Data;
using ECom.Services.Products.Models;
using ECom.Services.Products.Utility;
using Messages;
using Messages.DiscountMessages;
using NServiceBus.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECom.Services.Products.Handler
{
    public class DiscountHandler : 
        IHandleMessages<GetAllDiscount>,
        IHandleMessages<CreateDiscount>,
        IHandleMessages<UpdateDiscount>,
        IHandleMessages<DeleteDiscount>
    {
        private IMapper mapper;
        static ILog log = LogManager.GetLogger<DiscountHandler>();

        public DiscountHandler()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
            });
            this.mapper = config.CreateMapper();
        }

        public async Task Handle(GetAllDiscount message, IMessageHandlerContext context)
        {
            log.Info("Received message");
            var responseMessage = new Response<DiscountDto>();
            try
            {
                List<Discount> products = DataAccess.Ins.DB.Discounts.OrderBy(u => u.Id).ToList();
                responseMessage.responseData = products.Select(
                    emp => mapper.Map<DiscountDto>(emp)
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

        public async Task Handle(CreateDiscount message, IMessageHandlerContext context)
        {
            var responseMessage = new Response<DiscountDto>();
            if (message.discount == null)
            {
                log.Error("BadRequest, missing product info");
                responseMessage.ErrorCode = 403;
            }
            else
            {
                Discount newDiscount = mapper.Map<Discount>(message.discount);
                try
                {
                    log.Info("Adding new Discount");
                    DataAccess.Ins.DB.Discounts.Add(newDiscount);
                    DataAccess.Ins.DB.SaveChanges();
                    log.Info("Discount added");
                    responseMessage.responseData = new List<DiscountDto>() { mapper.Map<DiscountDto>(newDiscount) };
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

        public async Task Handle(UpdateDiscount message, IMessageHandlerContext context)
        {
            var responseMessage = new Response<DiscountDto>();
            if (message.id == 0)
            {
                log.Error("BadRequest, missing product id");
                responseMessage.ErrorCode = 403;
            }
            else
            {
                try
                {
                    DiscountDto newDiscount = message.discount;
                    Discount discount = DataAccess.Ins.DB.Discounts.First(x => x.Id == message.id);
                    discount.Name = newDiscount.Name;
                    discount.DiscountAmount = newDiscount.DiscountAmount;
                    DataAccess.Ins.DB.SaveChanges();
                    responseMessage.ErrorCode = 200;
                }
                catch (Exception ex)
                {
                    log.Error(ex.ToString());
                    responseMessage.ErrorCode = 500;
                }
            }
            await context.Reply(responseMessage).ConfigureAwait(false);
        }

        public async Task Handle(DeleteDiscount message, IMessageHandlerContext context)
        {
            var responseMessage = new Response<DiscountDto>();
            if (message.Id == 0)
            {
                log.Error("BadRequest, missing product id");
                responseMessage.ErrorCode = 403;
            }
            else
            {
                try
                {

                    Discount discount = DataAccess.Ins.DB.Discounts.First(u => u.Id == message.Id);
                    DataAccess.Ins.DB.Discounts.Remove(discount);
                    DataAccess.Ins.DB.SaveChanges();
                    responseMessage.ErrorCode = 200;
                }
                catch (Exception ex)
                {
                    log.Error(ex.ToString());
                    responseMessage.ErrorCode = 500;
                }
            }
            await context.Reply(responseMessage).ConfigureAwait(false);
        }
    }
}
