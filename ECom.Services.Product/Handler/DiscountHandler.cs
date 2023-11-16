using AutoMapper;
using Dto.ProductDto;
using ECom.Services.Products.Data;
using ECom.Services.Products.Models;
using ECom.Services.Products.Utility;
using Messages;
using NServiceBus.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECom.Services.Products.Handler
{
    public class DiscountHandler : IHandleMessages<GetAllDiscount>
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
    }
}
