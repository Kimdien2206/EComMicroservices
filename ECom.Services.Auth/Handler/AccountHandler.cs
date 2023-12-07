using AutoMapper;
using ECom.Services.Auth.Utility;
using NServiceBus.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECom.Services.Auth.Handler
{
    public class AccountHandler 
    {
        private IMapper mapper;
        static ILog log = LogManager.GetLogger<AccountHandler>();

        public AccountHandler()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
            });
            this.mapper = config.CreateMapper();
        }


    }
}
