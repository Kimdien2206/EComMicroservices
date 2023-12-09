using AutoMapper;
using Dto.OrderDto;
using ECom.Services.Reports.Data;
using ECom.Services.Reports.Models;
using ECom.Services.Reports.Utility;
using Messages;
using Messages.OrderMessages;
using Messages.ProductMessages;
using NServiceBus.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECom.Services.Reports.Handler
{
    public class ReportHandler
    {
        private IMapper mapper;
        static ILog log = LogManager.GetLogger<ReportHandler>();

        public ReportHandler()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
            });
            this.mapper = config.CreateMapper();
        }

        
    }
}
