using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using NServiceBus.Logging;

namespace ECom.Gateway.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ImportingController : BaseController
    {
        private readonly IMessageSession messageSession;
        private readonly ILog log = LogManager.GetLogger(typeof(DiscountController));

        public ImportingController(IMessageSession messageSession)
        {
            this.messageSession = messageSession;
        }

        [HttpGet]
        [EnableCors]
        public async Task<IActionResult> GetAllImporting()
        {

        }
    }
}
