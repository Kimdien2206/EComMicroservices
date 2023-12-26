using Dto.OrderDto;
using Messages.OrderMessages;
using Messages;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using NServiceBus.Logging;
using System.Net;
using Messages.ImportingMessages;
using Dto.ProductDto;
using Messages.ProductMessages;

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
            log.Info("Received request");
            var message = new GetAllImporting();
            try
            {
                var response = await this.messageSession.Request<Response<ImportingDto>>(message);
                log.Info($"Message sent, received: {response.responseData}");
                return ReturnWithStatus(response);
            }
            catch (OperationCanceledException ex)
            {
                log.Info($"Message sent, but {ex}");
                Request.HttpContext.Response.StatusCode = (int)HttpStatusCode.RequestTimeout;
                return StatusCode(500);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateImporting(ImportingDto newImporting)
        {
            if (newImporting == null)
            {
                return BadRequest();
            }
            try
            {
                newImporting.TotalCost = 0;
                newImporting.TotalAmount = 0;
                foreach (ImportDetailDto detail in newImporting.ImportDetails)
                {
                    detail.TotalCost = detail.Quantity * detail.Price;
                    newImporting.TotalCost += detail.TotalCost;
                    newImporting.TotalAmount += detail.Quantity;
                }

                var message = new CreateImporting() { newImporting = newImporting };
                var response = await this.messageSession.Request<Response<ImportingDto>>(message);
                return ReturnWithStatus(response);
            }
            catch
            {
                return StatusCode(500);
            }
        }
    }
}
