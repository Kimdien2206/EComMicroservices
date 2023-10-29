using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Messages;
using NServiceBus.Logging;

namespace ECom.Services.Product.Handler
{
    public class ProductHandler : IHandleMessages<GetAllProduct>
    {
        public async Task Handle(GetAllProduct message, IMessageHandlerContext context)
        {
            log.Info("Received message");
        }

        static ILog log = LogManager.GetLogger<ProductHandler>();
    }
}
