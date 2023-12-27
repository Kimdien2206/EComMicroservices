using AutoMapper;
using Dto.CartDto;
using ECom.Services.Carts.Data;
using ECom.Services.Carts.Models;
using ECom.Services.Carts.Utility;
using Messages;
using Messages.CartMessages;
using NServiceBus.Logging;

namespace ECom.Services.Carts.Handler
{
    public class CartHandler : IHandleMessages<GetCartByUser>, IHandleMessages<CreateCart>, IHandleMessages<UpdateQuantity>, IHandleMessages<RemoveCart>
    {
        private IMapper mapper;
        static ILog log = LogManager.GetLogger<CartHandler>();

        public CartHandler()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
            });
            this.mapper = config.CreateMapper();
        }

        public async Task Handle(GetCartByUser message, IMessageHandlerContext context)
        {
            var response = new Response<CartDto>();

            try
            {
                var cart = DataAccess.Ins.DB.Carts.Where(cart => cart.PhoneNumber == message.PhoneNumber).ToList();

                if (cart.Count > 0)
                {
                    response.responseData = cart.Select(cart => mapper.Map<CartDto>(cart)).ToList();
                    response.ErrorCode = 200;
                }
                else
                {
                    response.ErrorCode = 404;
                }
            }
            catch (Exception e)
            {
                log.Error($"Error message: {e.Message}");
                log.Error(e.StackTrace);
                response.ErrorCode = 500;
            }

            await context.Reply(response);
        }

        public async Task Handle(CreateCart message, IMessageHandlerContext context)
        {
            var response = new Response<string>();

            try
            {
                var carts = message.newCart.Details.Select(detail => new Cart() { ItemId = detail.ItemId, PhoneNumber = message.newCart.PhoneNumber, Quantity = detail.Quantity });
                var cart = DataAccess.Ins.DB.Carts.Where(cart => cart.PhoneNumber == message.newCart.PhoneNumber).ToList();

                if (cart.Count > 0)
                {
                    response.responseData = new List<string>() { "Cart is already existed." };
                    response.ErrorCode = 400;
                }
                else
                {
                    DataAccess.Ins.DB.Carts.AddRange(carts);
                    DataAccess.Ins.DB.SaveChanges();

                    response.ErrorCode = 201;
                }
            }
            catch (Exception e)
            {
                log.Error($"Error message: {e.Message}");
                log.Error(e.StackTrace);
                response.ErrorCode = 500;
            }

            await context.Reply(response);
        }

        public async Task Handle(UpdateQuantity message, IMessageHandlerContext context)
        {
            var response = new Response<string>();

            try
            {
                var carts = DataAccess.Ins.DB.Carts.Where(cart => cart.Id == message.PhoneNumber).ToList();

                if (carts.Count > 0)
                {
                    foreach (var cart in carts)
                    {
                        var cartTemp = message.Details.FirstOrDefault(ele => ele.ItemId == cart.ItemId);
                        if (cartTemp != null)
                        {
                            cart.Quantity = cartTemp.Quantity;
                        }
                    }

                    DataAccess.Ins.DB.SaveChanges();

                    response.ErrorCode = 200;
                }
                else
                {
                    response.ErrorCode = 404;
                }
            }
            catch (Exception e)
            {
                log.Error($"Error message: {e.Message}");
                log.Error(e.StackTrace);
                response.ErrorCode = 500;
            }

            await context.Reply(response);
        }

        public async Task Handle(RemoveCart message, IMessageHandlerContext context)
        {
            var response = new Response<string>();

            try
            {
                var carts = DataAccess.Ins.DB.Carts.Where(cart => cart.Id == message.CartId).ToList();

                if (carts.Count > 0)
                {
                    foreach (var cart in carts)
                    {
                        var cartTemp = message.Details.FirstOrDefault(ele => ele.ItemId == cart.ItemId);
                        if (cartTemp != null)
                        {
                            cart.Quantity = cartTemp.Quantity;
                        }
                    }

                    DataAccess.Ins.DB.SaveChanges();

                    response.ErrorCode = 200;
                }
                else
                {
                    response.ErrorCode = 404;
                }
            }
            catch (Exception e)
            {
                log.Error($"Error message: {e.Message}");
                log.Error(e.StackTrace);
                response.ErrorCode = 500;
            }

            await context.Reply(response);
        }
    }
}
