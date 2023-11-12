using Dto.ProductDto;
using Messages;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using NServiceBus.Logging;

namespace ECom.Gateway.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IMessageSession massageSession;
        static public ILog log = LogManager.GetLogger(typeof(ProductController));

        public ProductController(IMessageSession messageSession)
        {
            this.massageSession = messageSession;
        }

        [HttpGet]
        [EnableCors]
        public async void GetAllProduct() {

            log.Info("Received request");
            var message = new GetAllProduct();
            var response = await this.massageSession.Request<GetAllProductRes>(message);
            log.Info($"Message sent, received: {response.productDtos}");
        }
    }
}
