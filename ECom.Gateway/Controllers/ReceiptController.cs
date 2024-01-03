using System.Net;
using Dto.ReceiptDto;
using Messages;
using Messages.ReceiptMessages;
using Microsoft.AspNetCore.Mvc;
using NServiceBus.Logging;

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
            var message = new GetReceiptByStatus() { Status = '0' };
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

        [HttpGet]
        [Route("paid")]
        public async Task<IActionResult> GetPaidReceipt()
        {

            log.Info("Received request");
            var message = new GetReceiptByStatus() { Status = '1' };
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

        [HttpPost]
        public async Task<IActionResult> CreateReceipt(ReceiptDto newReceipt)
        {
            if (newReceipt == null)
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

        [HttpPost]
        [Route("payment/{receiptId}")]
        public async Task<IActionResult> CreatePaymentUrl(uint receiptId, [FromBody] VNPayPaymentDto paymentDto, [FromQuery] int orderId = 0)
        {
            if (paymentDto == null)
            {
                return BadRequest();
            }

            var curTimeStamp = DateTime.UtcNow.ToString("yyyyMMddHHmmss");

            var message = new CreateVNPayUrl() { Amount = paymentDto.Amount, CreateDate = curTimeStamp, TxnRef = receiptId, OrderId = orderId };

            try
            {
                var response = await this.messageSession.Request<Response<string>>(message);
                log.Info($"Message sent, received: {response.responseData}");
                return ReturnWithStatus(response);
            }
            catch (Exception ex)
            {
                log.Info($"Message sent, but {ex}");
                return StatusCode(500);
            }
        }

        [HttpPost]
        [Route("payment/{receiptId}/confirm")]
        public async Task<IActionResult> validateReceiptPayment(uint receiptId, VNPayPaymentResponseDto paymentDto)
        {
            if (paymentDto == null)
            {
                return BadRequest();
            }

            var message = new ValidateReceiptPayment()
            {
                vnp_Amount = paymentDto.vnp_Amount,
                vnp_BankCode = paymentDto.vnp_BankCode,
                vnp_CardType = paymentDto.vnp_CardType,
                vnp_BankTranNo = paymentDto.vnp_BankTranNo,
                vnp_OrderInfo = paymentDto.vnp_OrderInfo,
                vnp_PayDate = paymentDto.vnp_PayDate,
                vnp_TmnCode = paymentDto.vnp_TmnCode,
                vnp_TransactionStatus = paymentDto.vnp_TransactionStatus,
                vnp_ResponseCode = paymentDto.vnp_ResponseCode,
                vnp_SecureHash = paymentDto.vnp_SecureHash,
                vnp_TransactionNo = paymentDto.vnp_TransactionNo,
                vnp_TxnRef = paymentDto.vnp_TxnRef
            };
            try
            {
                var response = await this.messageSession.Request<Response<string>>(message);
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
            if (id == null)
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
