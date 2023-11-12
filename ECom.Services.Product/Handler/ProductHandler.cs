using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECom.Services.Products.Data;
using Messages;
using NServiceBus.Logging;
using ECom.Services.Products.Models;
using Dto.ProductDto;
using NServiceBus;
using AutoMapper;
using ECom.Services.Products.Utility;

namespace ECom.Services.Products.Handler
{
    public class ProductHandler : IHandleMessages<GetAllProduct>
    {
        private IMapper mapper;

        public ProductHandler()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
            });
            this.mapper = config.CreateMapper();
        }

        public async Task Handle(GetAllProduct message, IMessageHandlerContext context)
        {
            log.Info("Received message");
            List<Product> products = DataAccess.Ins.DB.Products.ToList();
            var responseMessage = new GetAllProductRes
            {
                productDtos = products.Select(
                emp => mapper.Map<Product, ProductDto>(emp)
                )
            };
            var options = new ReplyOptions();
            await context.Reply(responseMessage).ConfigureAwait(false);
            log.Info("Response sent");
        }

        static ILog log = LogManager.GetLogger<ProductHandler>();
    }
}
