using System.Text.Json;
using AutoMapper;
using Dto.ProductDto;
using ECom.Services.Products.Data;
using ECom.Services.Products.Models;
using ECom.Services.Products.Utility;
using Messages;
using Messages.VoucherMessage;
using Microsoft.EntityFrameworkCore;
using NServiceBus.Logging;

namespace ECom.Services.Products.Handler
{

    public class VoucherHandler :
        IHandleMessages<GetAllVoucherCommand>,
        IHandleMessages<CreateVoucherCommand>,
        IHandleMessages<UpdateVoucherCommand>,
        IHandleMessages<DeleteVoucherCommand>
    {
        private IMapper mapper;
        static ILog log = LogManager.GetLogger<VoucherHandler>();
        public VoucherHandler()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
            });
            this.mapper = config.CreateMapper();
        }
        public async Task Handle(GetAllVoucherCommand message, IMessageHandlerContext context)
        {
            var response = new Response<VoucherDto>();

            try
            {
                var vouchers = DataAccess.Ins.DB.Vouchers.OrderByDescending(voucher => voucher.Due).ToList();

                Console.WriteLine(JsonSerializer.Serialize(vouchers));

                response.responseData = vouchers.Select(voucher => mapper.Map<VoucherDto>(voucher));
                response.ErrorCode = 200;
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                response.ErrorCode = 500;
            }

            await context.Reply(response);
        }

        public async Task Handle(CreateVoucherCommand message, IMessageHandlerContext context)
        {
            var response = new Response<VoucherDto>();

            try
            {
                var voucher = DataAccess.Ins.DB.Vouchers.FirstOrDefault(voucher => voucher.Code == message.Voucher.Code);

                if (voucher == null)
                {
                    Voucher voucherModel = mapper.Map<Voucher>(message.Voucher);
                    DataAccess.Ins.DB.Vouchers.Add(voucherModel);

                    response.responseData = new List<VoucherDto>() { mapper.Map<VoucherDto>(voucherModel) };
                    response.ErrorCode = 200;

                    DataAccess.Ins.DB.SaveChanges();
                }
                else
                {
                    response.ErrorCode = 400;
                }
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                response.ErrorCode = 500;
            }

            await context.Reply(response);
        }

        public async Task Handle(UpdateVoucherCommand message, IMessageHandlerContext context)
        {
            var response = new Response<VoucherDto>();
            try
            {
                var voucher = DataAccess.Ins.DB.Vouchers.FirstOrDefault(voucher => voucher.Code == message.Code);

                if (voucher != null)
                {
                    var code = voucher.Code;
                    mapper.Map(message.Voucher, voucher);

                    voucher.Code = code;

                    response.responseData = new List<VoucherDto>() { mapper.Map<VoucherDto>(voucher) };
                    response.ErrorCode = 200;

                    DataAccess.Ins.DB.SaveChanges();
                }
                else
                {
                    response.ErrorCode = 400;
                }
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                response.ErrorCode = 500;
            }

            await context.Reply(response);
        }

        public async Task Handle(DeleteVoucherCommand message, IMessageHandlerContext context)
        {
            var response = new Response<string>();
            try
            {
                DataAccess.Ins.DB.Vouchers.Where(voucher => voucher.Code == message.Code).ExecuteDelete();

                response.responseData = new List<string>() { "Ok" };
                response.ErrorCode = 200;
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                response.ErrorCode = 500;
            }

            await context.Reply(response);
        }
    }
}
