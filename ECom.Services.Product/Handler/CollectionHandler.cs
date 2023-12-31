using AutoMapper;
using Dto.ProductDto;
using ECom.Services.Products.Data;
using ECom.Services.Products.Models;
using ECom.Services.Products.Utility;
using Messages;
using Messages.CollectionMessages;
using Microsoft.EntityFrameworkCore;
using NServiceBus.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECom.Services.Products.Handler
{
    public class CollectionHandler :
        IHandleMessages<GetAllCollection>,
        IHandleMessages<UpdateCollection>,
        IHandleMessages<CreateCollection>,
        IHandleMessages<DeleteCollection>
    {
        private IMapper mapper;
        static ILog log = LogManager.GetLogger<CollectionHandler>();

        public CollectionHandler()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
            });
            this.mapper = config.CreateMapper();
        }
        public async Task Handle(GetAllCollection message, IMessageHandlerContext context)
        {
            log.Info("Received message");
            var responseMessage = new Response<CollectionDto>();
            try
            {
                List<Collection> products = DataAccess.Ins.DB.Collections.OrderBy(u => u.Id).ToList();
                responseMessage.responseData = products.Select(
                    emp => mapper.Map<CollectionDto>(emp)
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

        public async Task Handle(CreateCollection message, IMessageHandlerContext context)
        {
            var responseMessage = new Response<CollectionDto>();
            if (message.newCollection == null)
            {
                log.Error("BadRequest, missing collection info");
                responseMessage.ErrorCode = 403;
            }
            else
            {
                Collection newCollection = mapper.Map<Collection>(message.newCollection);
                try
                {
                    log.Info("Adding new Collection");
                    DataAccess.Ins.DB.Collections.Add(newCollection);
                    DataAccess.Ins.DB.SaveChanges();
                    log.Info("Collection added");
                    responseMessage.ErrorCode = 200;
                    responseMessage.responseData = new List<CollectionDto>() { mapper.Map<CollectionDto>(newCollection) };
                }
                catch (Exception ex)
                {
                    log.Error($"Error: {ex}");
                    responseMessage.ErrorCode = 500;
                }
            }
            await context.Reply(responseMessage).ConfigureAwait(false);
        }

        public async Task Handle(UpdateCollection message, IMessageHandlerContext context)
        {
            var responseMessage = new Response<CollectionDto>();
            if (message.id == 0)
            {
                log.Error("BadRequest, missing product id");
                responseMessage.ErrorCode = 403;
            }
            else
            {
                try
                {
                    CollectionDto newCollection = message.collection;
                    Collection discount = DataAccess.Ins.DB.Collections.First(x => x.Id == message.id);
                    discount.Name = newCollection.Name;
                    discount.DiscountId = newCollection.DiscountId;
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

        public async Task Handle(DeleteCollection message, IMessageHandlerContext context)
        {
            var responseMessage = new Response<CollectionDto>();
            if (message.Id == 0)
            {
                log.Error("BadRequest, missing product id");
                responseMessage.ErrorCode = 403;
            }
            else
            {
                try
                {

                    Collection collection = DataAccess.Ins.DB.Collections.First(u => u.Id == message.Id);
                    DataAccess.Ins.DB.Collections.Remove(collection);
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
    }
}
