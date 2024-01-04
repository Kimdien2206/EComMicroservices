using AutoMapper;
using Dto.ProductDto;
using ECom.Services.Products.Data;
using ECom.Services.Products.Models;
using ECom.Services.Products.Utility;
using Messages;
using Messages.CollectionMessages;
using Messages.DiscountMessages;
using Messages.ProductMessages;
using Microsoft.EntityFrameworkCore;
using NServiceBus.Logging;

namespace ECom.Services.Products.Handler
{
    public class ProductHandler :
        IHandleMessages<GetAllProduct>,
        IHandleMessages<ViewProduct>,
        IHandleMessages<CreateProduct>,
        IHandleMessages<GetProductBySlug>,
        IHandleMessages<GetBestSellers>,
        IHandleMessages<GetMostViewed>,
        IHandleMessages<UpdateProduct>,
        IHandleMessages<ProductSold>,
        IHandleMessages<GetProductByItemID>,
        IHandleMessages<GetActiveProduct>,
        IHandleMessages<GetProductOfCollection>,
        IHandleMessages<GetProductByTagId>,
        IHandleMessages<GetProductDetail>,
        IHandleMessages<GetProductOfDiscount>,
        IHandleMessages<GetSimilarProducts>,
        IHandleMessages<GetAllProductIdsCommand>
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
            log.Info("Received message GetAllProduct");
            var responseMessage = new Response<ProductDto>();
            try
            {
                List<Product> products = DataAccess.Ins.DB.Products.Include("ProductItems").OrderBy(u => u.Id).ToList();
                log.Info(products.Count.ToString());
                responseMessage.responseData = products.Select(
                    emp => mapper.Map<ProductDto>(emp)
                    );
                responseMessage.ErrorCode = 200;
                log.Info("Response sent");
            }
            catch (Exception e)
            {
                log.Error(e.Message);
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
            if (message.newProduct == null)
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
                    DataAccess.Ins.DB.SaveChanges();
                    log.Info("Product added");
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

        public async Task Handle(GetProductBySlug message, IMessageHandlerContext context)
        {
            var responseMessage = new Response<ProductDto>();
            if (message.ProductSlug == null)
            {
                log.Error("BadRequest, missing product id");
                responseMessage.ErrorCode = 400;
            }
            else
            {
                string slug = message.ProductSlug;
                try
                {
                    var product = DataAccess.Ins.DB.Products.Where(ele => ele.Slug == slug).Include(ele => ele.ProductItems).Include(u => u.HaveTags).FirstOrDefault();
                    if (product != null)
                    {
                        responseMessage.responseData = new List<ProductDto>() { mapper.Map<ProductDto>(product) };
                        responseMessage.ErrorCode = 200;
                    }
                    else
                    {
                        responseMessage.ErrorCode = 404;
                    }
                }
                catch (Exception ex)
                {
                    log.Error(ex.ToString());
                    responseMessage.ErrorCode = 500;
                }
            }
            await context.Reply(responseMessage).ConfigureAwait(false);
        }
        
        public async Task Handle(GetSimilarProducts message, IMessageHandlerContext context)
        {
            var responseMessage = new Response<ProductDto>();
            if (message.Id == null)
            {
                log.Error("BadRequest, missing product id");
                responseMessage.ErrorCode = 400;
            }
            else
            {
                try
                {
                    List<HaveTag> haveTags = DataAccess.Ins.DB.HasTags.Where(ele => ele.ProductId == message.Id).ToList();

                    List<int> tagIds = new List<int>(); 
                    foreach(HaveTag haveTag in haveTags)
                    {
                        tagIds.Add(haveTag.Id);
                    }

                    List<HaveTag> similarHaveTags = new List<HaveTag>();
                    foreach(int Id in tagIds)
                    {
                        HaveTag similarHaveTag = DataAccess.Ins.DB.HasTags.FirstOrDefault(u => u.TagId == Id);
                        if(similarHaveTags != null)
                        {
                            similarHaveTags.Add(similarHaveTag);
                        }
                    }

                    List<Product> products = new List<Product>();

                    foreach (HaveTag similarTag in similarHaveTags)
                    {
                        Product product = DataAccess.Ins.DB.Products.FirstOrDefault(u => u.Id == similarTag.ProductId);

                        if (product != null && !products.Contains(product))
                        {
                            products.Add(product);
                        }
                    }

                    List<Product> response = products.Take(10).ToList();

                    responseMessage.responseData = response.Select(emp => mapper.Map<ProductDto>(emp));
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

        public Task Handle(ProductSold message, IMessageHandlerContext context)
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
            return Task.CompletedTask;
        }

        public async Task Handle(GetProductByItemID message, IMessageHandlerContext context)
        {
            var responseMessage = new Response<ProductDto>();
            if (message.ItemId == 0)
            {
                log.Error("BadRequest, missing product id");
                responseMessage.ErrorCode = 400;
            }
            else
            {
                int itemId = message.ItemId;
                try
                {
                    ProductItem productItem = DataAccess.Ins.DB.ProductItems.Where(u => u.Id == itemId).First();

                    if (productItem != null)
                    {
                        List<Product> products = DataAccess.Ins.DB.Products.Where(u => u.Id == productItem.ProductId).ToList();
                        responseMessage.responseData = products.Select(emp => mapper.Map<ProductDto>(emp));
                        responseMessage.ErrorCode = 200;
                    }
                    else
                    {
                        log.Error("Product not found");
                        responseMessage.ErrorCode = 404;
                    }

                }
                catch (Exception ex)
                {
                    log.Error(ex.ToString());
                    responseMessage.ErrorCode = 500;
                }
            }
            await context.Reply(responseMessage).ConfigureAwait(false);
        }

        public async Task Handle(GetActiveProduct message, IMessageHandlerContext context)
        {
            var responseMessage = new Response<int>();
            try
            {

                int activeProductCount = DataAccess.Ins.DB.Products.Where(u => u.IsActive == true).Count();
                responseMessage.responseData = new List<int> { activeProductCount };
                responseMessage.ErrorCode = 200;
            }
            catch (Exception ex)
            {
                log.Error(ex.ToString());
                responseMessage.ErrorCode = 500;
            }

            await context.Reply(responseMessage).ConfigureAwait(false);
        }

        public async Task Handle(GetProductByTagId message, IMessageHandlerContext context)
        {
            var responseMessage = new Response<ProductDto>();
            try
            {

                List<HaveTag> tags = DataAccess.Ins.DB.HasTags.Where(u => u.TagId == message.TagID).ToList();

                List<Product> products = new List<Product>();

                foreach(HaveTag item in tags)
                {
                    Product product = DataAccess.Ins.DB.Products.Where(i => i.Id == item.ProductId).FirstOrDefault();
                    products.Add(product);
                }

                responseMessage.responseData = products.Select(emp => mapper.Map<ProductDto>(emp));
                responseMessage.ErrorCode = 200;
            }
            catch (Exception ex)
            {
                log.Error(ex.ToString());
                responseMessage.ErrorCode = 500;
            }

            await context.Reply(responseMessage).ConfigureAwait(false);
        } 
        
        public async Task Handle(GetProductOfDiscount message, IMessageHandlerContext context)
        {
            var responseMessage = new Response<ProductDto>();
            try
            {

                List<Product> products = DataAccess.Ins.DB.Products.Where(u => u.DiscountId == message.Id).ToList();

                responseMessage.responseData = products.Select(emp => mapper.Map<ProductDto>(emp));
                responseMessage.ErrorCode = 200;
            }
            catch (Exception ex)
            {
                log.Error(ex.ToString());
                responseMessage.ErrorCode = 500;
            }

            await context.Reply(responseMessage).ConfigureAwait(false);
        } 
        
        public async Task Handle(GetProductDetail message, IMessageHandlerContext context)
        {
            var responseMessage = new Response<ProductDto>();
            try
            {
                ProductItem item = DataAccess.Ins.DB.ProductItems.Where(u => u.Id == message.ProductDetailId).First();

                    Product product = DataAccess.Ins.DB.Products
                        .Include("ProductItems")
                        .Where(i => i.Id == item.Id)
                        .First();

                List<Product> products = new List<Product>() { product };
             

                responseMessage.responseData = products.Select(emp => mapper.Map<ProductDto>(emp));
                responseMessage.ErrorCode = 200;
            }
            catch (Exception ex)
            {
                log.Error(ex.ToString());
                responseMessage.ErrorCode = 500;
            }

            await context.Reply(responseMessage).ConfigureAwait(false);
        } 
        
        public async Task Handle(GetProductOfCollection message, IMessageHandlerContext context)
        {
            var responseMessage = new Response<ProductDto>();
            try
            {
                List<Product> products = DataAccess.Ins.DB.Products.Where(u => u.CollectionId == message.Id).ToList();

                responseMessage.responseData = products.Select(emp => mapper.Map<ProductDto>(emp));
                responseMessage.ErrorCode = 200;
            }
            catch (Exception ex)
            {
                log.Error(ex.ToString());
                responseMessage.ErrorCode = 500;
            }

            await context.Reply(responseMessage).ConfigureAwait(false);
        }

        public Task Handle(GetAllProductIdsCommand message, IMessageHandlerContext context)
        {
            var respondMessage = new GetAllProductIdsResponse();
            respondMessage.SagaId = message.SagaId;
            try
            {
                List<Product> products = DataAccess.Ins.DB.Products.ToList();
                respondMessage.ProductIds = products.Select(
                    emp => emp.Id).ToList();

                context.Send(respondMessage).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                log.Error($"Error: {ex.Message}");
                log.Error(ex.StackTrace);
            }

            return Task.CompletedTask;
        }


    }
}
