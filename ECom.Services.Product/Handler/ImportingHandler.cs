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
            log.Info($"Receiving {message.GetType()}");

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

                foreach(ImportDetail detail in newImporting.ImportDetails) 
                {
                    ProductItem productItem = DataAccess.Ins.DB.ProductItems.First(u => u.Id == detail.Item);
                    productItem.Quantity += detail.Quantity;
                }

                try
                {
                    log.Info("Adding new Importing");
                    DataAccess.Ins.DB.Importings.Add(newImporting);
                    DataAccess.Ins.DB.SaveChanges();
                    log.Info("Importing added");

                    var publishMessage = new ImportingCreated()
                    {
                        TotalCost = (ulong)newImporting.TotalCost,
                        Date = DateOnly.FromDateTime(newImporting.Date)
                    };
                    await context.Publish(publishMessage);
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
                List<Importing> importings = DataAccess.Ins.DB.Importings
                    .Include(x => x.ImportDetails)
                    .OrderBy(u => u.Date)
                    .ToList();

                List<ImportingDto> importingDtos = new List<ImportingDto> ();

                foreach (Importing item in importings)
                {
                    ImportingDto importingDto = mapper.Map<ImportingDto>(item);
                    importingDto.ImportDetails = [];

                    foreach (ImportDetail detail in item.ImportDetails)
                    {
                        //get productItem
                        ProductItem productItem = DataAccess.Ins.DB.ProductItems.First(u => u.Id == detail.Item);
                        
                        //get product
                        Product product = DataAccess.Ins.DB.Products.First(u => u.Id == productItem.ProductId);

                        //link productItem to product
                        //product.ProductItems.Add(productItem);

                        ImportDetailDto importDetailDto = mapper.Map<ImportDetailDto>(detail);

                        //link product to importDetail
                        importDetailDto.Product = mapper.Map<ProductDto>(product);

                        //link importDetail to import
                        importingDto.ImportDetails.Add(importDetailDto);
                    }
                    importingDtos.Add(importingDto);
                }

                responseMessage.responseData = importingDtos;
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
