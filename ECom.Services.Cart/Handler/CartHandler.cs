using AutoMapper;
using Dto.CartDto;
using ECom.Services.Carts.Data;
using ECom.Services.Carts.Models;
using ECom.Services.Carts.Utility;
using Messages;
using Messages.CartMessages;
using Microsoft.EntityFrameworkCore;
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
                var cartToUpsert = mapper.Map<Cart>(message.newCart);
                var cart = DataAccess.Ins.DB.Carts.FirstOrDefault(cart => cart.PhoneNumber == message.newCart.PhoneNumber && cart.ItemId == message.newCart.ItemId);

                if (cart == null)
                {
                    DataAccess.Ins.DB.Carts.Add(cartToUpsert);
                }
                else
                {
                    DataAccess.Ins.DB.Carts.Update(cartToUpsert);
                }

                DataAccess.Ins.DB.SaveChanges();
                response.ErrorCode = 201;
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
                var cartToUpdate = DataAccess.Ins.DB.Carts.FirstOrDefault(cart => cart.PhoneNumber == message.CartDto.PhoneNumber && cart.ItemId == message.CartDto.ItemId);

                if (cartToUpdate != null)
                {
                    //cartToUpdate.Quantity = message.CartDto.Quantity;

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
                if (message.IsDeleteAll)
                {
                    DataAccess.Ins.DB.Carts.Where(ele => ele.PhoneNumber == message.PhoneNumber).ExecuteDelete();
                }
                else
                {
                    var idItemToDelete = message.RemoveDetail.ItemId;
                    DataAccess.Ins.DB.Carts.Where(ele => ele.PhoneNumber == message.PhoneNumber && idItemToDelete == ele.ItemId).ExecuteDelete();
                }

                response.ErrorCode = 204;
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
