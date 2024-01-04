using AutoMapper;
using Dto.ProductDto;
using ECom.Services.Products.Data;
using ECom.Services.Products.Utility;
using Messages;
using NServiceBus.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECom.Services.Products.Models;
using Messages.TagMessages;
using Microsoft.EntityFrameworkCore;

namespace ECom.Services.Products.Handler
{
    public class TagHandler :
        IHandleMessages<GetAllTag>,
        IHandleMessages<CreateTag>,
        IHandleMessages<UpdateTag>,
        IHandleMessages<DeleteTag>,
        IHandleMessages<GetTagById>
    {
        private IMapper mapper;
        static ILog log = LogManager.GetLogger<TagHandler>();

        public TagHandler()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
            });
            this.mapper = config.CreateMapper();
        }
        public async Task Handle(GetTagById message, IMessageHandlerContext context)
        {
            log.Info($"Received {message.GetType()} message");
                var responseMessage = new Response<TagDto>();
            if (message.Id == 0)
            {
                log.Info("Bad request");
            }
            else
            {
                try
                {
                    List<Tag> tags = DataAccess.Ins.DB.Tags.Where(u => u.Id == message.Id).ToList();
                    responseMessage.responseData = tags.Select(
                        emp => mapper.Map<TagDto>(emp)
                        );
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
        
        public async Task Handle(GetAllTag message, IMessageHandlerContext context)
        {
            log.Info("Received message");
            var responseMessage = new Response<TagDto>();
            try
            {
                List<Tag> tags = DataAccess.Ins.DB.Tags.Include("Discount").OrderBy(u => u.Id).ToList();
                responseMessage.responseData = tags.Select(
                    emp => mapper.Map<TagDto>(emp)
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

        public async Task Handle(CreateTag message, IMessageHandlerContext context)
        {
            var responseMessage = new Response<TagDto>();
            if (message.newTag == null)
            {
                log.Error("BadRequest, missing collection info");
                responseMessage.ErrorCode = 403;
            }
            else
            {
                Tag newTag = mapper.Map<Tag>(message.newTag);
                try
                {
                    log.Info("Adding new Tag");
                    DataAccess.Ins.DB.Tags.Add(newTag);
                    DataAccess.Ins.DB.SaveChanges();
                    log.Info("Tag added");
                    responseMessage.ErrorCode = 200;
                    responseMessage.responseData = new List<TagDto>() { mapper.Map<TagDto>(newTag) };
                }
                catch (Exception ex)
                {
                    log.Error($"Error: {ex}");
                    responseMessage.ErrorCode = 500;
                }
            }
            await context.Reply(responseMessage).ConfigureAwait(false);
        }

        public async Task Handle(UpdateTag message, IMessageHandlerContext context)
        {
            var responseMessage = new Response<TagDto>();
            if (message.Id == 0)
            {
                log.Error("BadRequest, missing product id");
                responseMessage.ErrorCode = 403;
            }
            else
            {
                try
                {
                    TagDto newTag = message.newTag;
                    Tag discount = DataAccess.Ins.DB.Tags.First(x => x.Id == message.Id);
                    discount.Name = newTag.Name;
                    discount.DiscountId = newTag.DiscountId;
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

        public async Task Handle(DeleteTag message, IMessageHandlerContext context)
        {
            var responseMessage = new Response<TagDto>();
            if (message.Id == 0)
            {
                log.Error("BadRequest, missing product id");
                responseMessage.ErrorCode = 403;
            }
            else
            {
                try
                {

                    Tag collection = DataAccess.Ins.DB.Tags.First(u => u.Id == message.Id);
                    DataAccess.Ins.DB.Tags.Remove(collection);
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
