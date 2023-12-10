using System.Text.Json;
using AutoMapper;
using Dto.ProductDto;
using ECom.Services.Products.Data;
using ECom.Services.Products.Models;
using ECom.Services.Products.Utility;
using Messages;
using Messages.VoucherMessage;
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

        public Task Handle(CreateVoucherCommand message, IMessageHandlerContext context)
        {
            throw new NotImplementedException();
        }

        public Task Handle(UpdateVoucherCommand message, IMessageHandlerContext context)
        {
            throw new NotImplementedException();
        }

        public Task Handle(DeleteVoucherCommand message, IMessageHandlerContext context)
        {
            throw new NotImplementedException();
        }
    }
}
