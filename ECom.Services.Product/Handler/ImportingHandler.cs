using AutoMapper;
using Dto.ProductDto;
using ECom.Services.Products.Data;
using ECom.Services.Products.Models;
using ECom.Services.Products.Utility;
using Messages;
using Messages.ImportingMessages;
using Microsoft.EntityFrameworkCore;
using NServiceBus.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECom.Services.Products.Handler
{
    public class ImportingHandler : 
        IHandleMessages<GetAllImporting>,
        IHandleMessages<CreateImporting>
    {
        private IMapper mapper;
        static ILog log = LogManager.GetLogger<ImportingHandler>();

        public ImportingHandler()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
            });
            this.mapper = config.CreateMapper();
        }

        public async Task Handle(CreateImporting message, IMessageHandlerContext context)
        {
            var responseMessage = new Response<ImportingDto>();
            if (message.newImporting == null)
            {
                log.Error("BadRequest, missing importing info");
                responseMessage.ErrorCode = 403;
            }
            else
            {
                Importing newImporting = mapper.Map<Importing>(message.newImporting);
                newImporting.Date = DateTime.Now;
                try
                {
                    log.Info("Adding new Importing");
                    DataAccess.Ins.DB.Importings.Add(newImporting);
                    DataAccess.Ins.DB.SaveChanges();
                    log.Info("Importing added");
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

        public async Task Handle(GetAllImporting message, IMessageHandlerContext context)
        {
            log.Info("Received message");
            var responseMessage = new Response<ImportingDto>();
            try
            {
                List<Importing> products = DataAccess.Ins.DB.Importings.Include("ImportDetails").OrderBy(x =>x.Date).ToList();
                responseMessage.responseData = products.Select(
                    emp => mapper.Map<ImportingDto>(emp)
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
