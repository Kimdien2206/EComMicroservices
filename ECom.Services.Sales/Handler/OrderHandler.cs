using AutoMapper;
using Dto.OrderDto;
using ECom.Services.Sales.Data;
using ECom.Services.Sales.Models;
using ECom.Services.Sales.Utility;
using Messages;
using Messages.OrderMessages;
using Messages.ProductMessages;
using Microsoft.EntityFrameworkCore;
using NServiceBus.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECom.Services.Sales.Handler
{
    public class OrderHandler : 
        IHandleMessages<GetAllOrder>,
        IHandleMessages<GetOrderByStatus>,
        IHandleMessages<UpdateOrderStatus>,
        IHandleMessages<CreateOrder>,
        IHandleMessages<GetOrderById>
    {
        private IMapper mapper;
        static ILog log = LogManager.GetLogger<OrderHandler>();

        public OrderHandler()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
            });
            this.mapper = config.CreateMapper();
        }

        public async Task Handle(GetAllOrder message, IMessageHandlerContext context)
        {
            log.Info("Received message");
            var responseMessage = new Response<OrderDto>();
            try
            {
                List<Order> orders = DataAccess.Ins.DB.Orders.OrderBy(u => u.Id).ToList();
                responseMessage.responseData = orders.Select(
                    emp => mapper.Map<OrderDto>(emp)
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

        public async Task Handle(GetOrderByStatus message, IMessageHandlerContext context)
        {
            log.Info("Received message");
            var responseMessage = new Response<OrderDto>();
            try
            {
                List<Order> orders = DataAccess.Ins.DB.Orders.Where(u => u.Status.Equals(message.Status)).OrderBy(u => u.Id).ToList();
                responseMessage.responseData = orders.Select(
                    emp => mapper.Map<OrderDto>(emp)
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

        public async Task Handle(UpdateOrderStatus message, IMessageHandlerContext context)
        {
            log.Info("Received message");
            var responseMessage = new Response<OrderDto>();
            int updateID = Int32.Parse(message.Id);

            if(message.Id == null || message.Status == ' ')
            {
                responseMessage.ErrorCode = 500;
            }
            else
            {
                try
                {
                    Order order = DataAccess.Ins.DB.Orders.Where(u => u.Id == updateID).First();
                    order.Status = message.Status;
                    DataAccess.Ins.DB.SaveChanges();
                    responseMessage.ErrorCode = 200;
                    log.Info("Response sent");
                }
                catch
                {
                    log.Info("Something went wrong");
                    responseMessage.ErrorCode = 500;
                }
            }
            await context.Reply(responseMessage).ConfigureAwait(false);
        }

        public async Task Handle(CreateOrder message, IMessageHandlerContext context)
        {
            var responseMessage = new Response<OrderDto>();
            if (message.newOrder == null)
            {
                log.Error("BadRequest, missing product info");
                responseMessage.ErrorCode = 403;
            }
            else
            {
                Order newOrder = mapper.Map<Order>(message.newOrder);
                newOrder.OrderDetails = message.newOrder.OrderDetails.Select(emp => mapper.Map<OrderDetail>(emp)).ToList();

                foreach(OrderDetail detail in newOrder.OrderDetails)
                {
                    var getProductPriceMessage = new GetProductByItemID() { ItemId = detail.ItemId };


                }


                try
                {
                    log.Info("Adding new Order");
                    DataAccess.Ins.DB.Orders.Add(newOrder);

                    DataAccess.Ins.DB.SaveChanges();


                    log.Info("Order added");
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

        public async Task Handle(GetOrderById message, IMessageHandlerContext context)
        {
            log.Info("Received message");
            var responseMessage = new Response<OrderDto>();
            try
            {
                List<Order> orders = DataAccess.Ins.DB.Orders.Include("OrderDetails").Where(u => u.Id == message.Id).ToList();
                responseMessage.responseData = orders.Select(
                    emp => mapper.Map<OrderDto>(emp)
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
