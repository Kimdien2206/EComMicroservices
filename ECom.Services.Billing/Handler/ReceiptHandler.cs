using AutoMapper;
using ECom.Services.Sales.Utility;
using NServiceBus.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECom.Services.Billing.Handler
{
    public class ReceiptHandler
    {
        private IMapper mapper;
        static ILog log = LogManager.GetLogger<ReceiptHandler>();

        public ReceiptHandler()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
            });
            this.mapper = config.CreateMapper();
        }
    }
}
