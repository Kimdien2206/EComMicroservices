using AutoMapper;
using Dto.ReceiptDto;
using ECom.Services.Carts.Data;
using ECom.Services.Carts.Models;
using ECom.Services.Carts.Utility;
using Messages;
using Messages.ProductMessages;
using Messages.ReceiptMessages;
using NServiceBus.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECom.Services.Carts.Handler
{
    public class CartHandler
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
    }
}
