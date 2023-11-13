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
    public class ProductHandler : 
        IHandleMessages<GetAllProduct>,
        IHandleMessages<ViewProduct>,
        IHandleMessages<CreateProduct>
    {
        private IMapper mapper;
        static ILog log = LogManager.GetLogger<ProductHandler>();

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
                ),
            };
            await context.Reply(responseMessage).ConfigureAwait(false);
            log.Info("Response sent");
        }

        public async Task Handle(ViewProduct message, IMessageHandlerContext context)
        {
            if (message.productID == 0)
            {
                log.Error("BadRequest, missing product id");
            }
            else
            {
                int productID = message.productID;
                Product product = DataAccess.Ins.DB.Products.First(x => x.Id == productID);
                product.View++;
                try
                {
                    DataAccess.Ins.DB.SaveChanges();
                }
                catch (Exception ex)
                {
                    log.Error(ex.ToString()); 
                }
            }
        }

        public async Task Handle(CreateProduct message, IMessageHandlerContext context)
        {
            if(message.newProduct == null)
            {
                log.Error("BadRequest, missing product info");
            }
            else
            {
                Product newProduct = mapper.Map<Product>(message.newProduct);
                try
                {
                    log.Info("Adding new Product");
                    DataAccess.Ins.DB.Products.Add(newProduct);
                    log.Info("Product added");
                }
                catch(Exception ex) 
                {
                    log.Error($"Error: {ex}");
                }
            }
        }
    }
}
