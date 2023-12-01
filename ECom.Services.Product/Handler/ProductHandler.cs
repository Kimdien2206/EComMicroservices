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
using Microsoft.EntityFrameworkCore;
using Messages.ProductMessages;

namespace ECom.Services.Products.Handler
{
    public class ProductHandler : 
        IHandleMessages<GetAllProduct>,
        IHandleMessages<ViewProduct>,
        IHandleMessages<CreateProduct>,
        IHandleMessages<GetProductByID>,
        IHandleMessages<GetBestSellers>,
        IHandleMessages<GetMostViewed>,
        IHandleMessages<UpdateProduct>,
        IHandleMessages<ProductSold>
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
            var responseMessage = new Response<ProductDto>();
            try
            {
                List<Product> products = DataAccess.Ins.DB.Products.OrderBy(u => u.Id).ToList();
                responseMessage.responseData = products.Select(
                    emp => mapper.Map<ProductDto>(emp)
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

        public async Task Handle(ViewProduct message, IMessageHandlerContext context)
        {
            var responseMessage = new Response<ProductDto>();
            if (message.productID == 0)
            {
                log.Error("BadRequest, missing product id");
                responseMessage.ErrorCode = 403;
            }
            else
            {
                try
                {
                    int productID = message.productID;
                    Product product = DataAccess.Ins.DB.Products.First(x => x.Id == productID);
                    product.View++;
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

        public async Task Handle(CreateProduct message, IMessageHandlerContext context)
        {
            var responseMessage = new Response<ProductDto>();
            if(message.newProduct == null)
            {
                log.Error("BadRequest, missing product info");
                responseMessage.ErrorCode = 403;
            }
            else
            {
                Product newProduct = mapper.Map<Product>(message.newProduct);
                try
                {
                    log.Info("Adding new Product");
                    DataAccess.Ins.DB.Products.Add(newProduct);
                    log.Info("Product added");
                    responseMessage.ErrorCode = 200;
                }
                catch(Exception ex) 
                {
                    log.Error($"Error: {ex}");
                    responseMessage.ErrorCode = 500;
                }
            }
            await context.Reply(responseMessage).ConfigureAwait(false);   
        }

        public async Task Handle(GetBestSellers message, IMessageHandlerContext context)
        {
            var responseMessage = new Response<ProductDto>();
            try
            {
                List<Product> products = DataAccess.Ins.DB.Products.OrderByDescending(u => u.Sold).Take(10).ToList();
                responseMessage.responseData = products.Select(
                emp => mapper.Map<ProductDto>(emp)
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

        public async Task Handle(GetProductByID message, IMessageHandlerContext context)
        {
            var responseMessage = new Response<ProductDto>();
            if (message.productSlug == null)
            {
                log.Error("BadRequest, missing product id");
                responseMessage.ErrorCode = 403;
            }
            else
            {
                string slug = message.productSlug;
                try
                {
                    List<Product> products = DataAccess.Ins.DB.Products.Where(u => u.Slug == slug)
                        .Include(item => item.ProductItems)
                        .ToList();

                    responseMessage.responseData = products.Select(emp => mapper.Map<ProductDto>(emp));
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

        public async Task Handle(GetMostViewed message, IMessageHandlerContext context)
        {
            var responseMessage = new Response<ProductDto>();
            try
            {
                List<Product> products = DataAccess.Ins.DB.Products.OrderByDescending(u => u.View).Take(10).ToList();
                responseMessage.responseData = products.Select(
                emp => mapper.Map<ProductDto>(emp)
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

        public async Task Handle(UpdateProduct message, IMessageHandlerContext context)
        {
            var responseMessage = new Response<ProductDto>();
            if (message.Id == 0)
            {
                log.Error("BadRequest, missing product id");
                responseMessage.ErrorCode = 403;
            }
            else
            {
                try
                {
                    ProductDto newProduct = message.product;
                    Product product = DataAccess.Ins.DB.Products.First(x => x.Id == message.Id);
                    product.Name = newProduct.Name;
                    product.Description = newProduct.Description;
                    product.Image = newProduct.Image;
                    product.IsActive = newProduct.IsActive;
                    product.DiscountId = newProduct.DiscountId;
                    product.CollectionId = newProduct.CollectionId;
                    product.Slug = newProduct.Slug;
                    product.Price = newProduct.Price;
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

        public async Task Handle(ProductSold message, IMessageHandlerContext context)
        {
            List<int> listId = message.Id;
            if (listId == null)
            {
                log.Error("BadRequest, missing product id");
            }
            else
            {
                try
                {
                    listId.ForEach(item =>
                    {
                        Product product = DataAccess.Ins.DB.Products.First(x => x.Id == item);
                        product.Sold++;

                    });
                    DataAccess.Ins.DB.SaveChanges();
                }
                catch (Exception ex)
                {
                    log.Error(ex.ToString());
                }
            }
        }
    }
}
