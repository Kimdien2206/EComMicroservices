using Dto.ReceiptDto;
using Messages.OrderMessages;
using Messages;
using Microsoft.AspNetCore.Mvc;
using NServiceBus.Logging;
using System.Net;
using Messages.ReceiptMessages;
using Dto.OrderDto;

namespace ECom.Gateway.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReceiptController : BaseController
    {
        private readonly IMessageSession messageSession;
        private readonly ILog log = LogManager.GetLogger(typeof(ReceiptController));
        public ReceiptController(IMessageSession messageSession)
        {
            this.messageSession = messageSession;
        }

        [HttpGet]
        [Route("unpaid")]
        public async Task<IActionResult> GetUnpaidReceipt()
        {

            log.Info("Received request");
            var getReceiptMessage = new GetReceiptByStatus() { Status = '0' };
            try
            {
                var getReceiptResponse = await this.messageSession.Request<Response<ReceiptDto>>(getReceiptMessage);
                log.Info($"Message sent, received: {getReceiptResponse.responseData}");


                var getOrderMessage = new GetOrderById( ) { Id = getReceiptResponse.responseData.First().OrderId };
                var getOrderResponse = await this.messageSession.Request<Response<OrderDto>>(getOrderMessage);
                log.Info($"Message sent, received: {getOrderResponse.responseData}");

                getReceiptResponse.responseData.First().OrderInfo = getOrderResponse.responseData.First();
                
                return ReturnWithStatus(getReceiptResponse);
            }
            catch (OperationCanceledException ex)
            {
                log.Info($"Message sent, but {ex}");
                Request.HttpContext.Response.StatusCode = (int)HttpStatusCode.RequestTimeout;
                return StatusCode(500);
            }
        }
        
        [HttpGet]
        [Route("paid")]
        public async Task<IActionResult> GetPaidReceipt()
        {

            log.Info("Received request");
            var getReceiptMessage = new GetReceiptByStatus() { Status = '1' };
            try
            {
                var getReceiptResponse = await this.messageSession.Request<Response<ReceiptDto>>(getReceiptMessage);
                log.Info($"Message sent, received: {getReceiptResponse.responseData}");

                foreach(ReceiptDto item in getReceiptResponse.responseData)
                {
                    var getOrderMessage = new GetOrderById() { Id = item.OrderId };
                    var getOrderResponse = await this.messageSession.Request<Response<OrderDto>>(getOrderMessage);
                    log.Info($"Message sent, received: {getOrderResponse.responseData}");

                    item.OrderInfo = getOrderResponse.responseData.First();
                }
                return ReturnWithStatus(getReceiptResponse);
            }
            catch (OperationCanceledException ex)
            {
                log.Info($"Message sent, but {ex}");
                Request.HttpContext.Response.StatusCode = (int)HttpStatusCode.RequestTimeout;
                return StatusCode(500);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateReceipt(ReceiptDto newReceipt)
        {
            if(newReceipt == null)
            {
                return BadRequest();
            }

            log.Info("Received request");
            var message = new CreateReceipt() { newReceipt = newReceipt };
            try
            {
                var response = await this.messageSession.Request<Response<ReceiptDto>>(message);
                log.Info($"Message sent, received: {response.responseData}");
                return ReturnWithStatus(response);
            }
            catch (Exception ex)
            {
                log.Info($"Message sent, but {ex}");
                return StatusCode(500);
            }
        }
        
        [HttpPatch]
        [Route("paid/{id}")]
        public async Task<IActionResult> PaidReceipt(string id)
        {
            if(id == null)
            {
                return BadRequest();
            }
            int receiptId = Int32.Parse(id);

            log.Info("Received request");
            var message = new PaidReceipt() { ReceiptId = receiptId };
            try
            {
                var response = await this.messageSession.Request<Response<ReceiptDto>>(message);
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
    }
}
