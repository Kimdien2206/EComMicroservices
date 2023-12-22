using System.Net;
using Dto.ProductDto;
using Messages;
using Messages.VoucherMessage;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using NServiceBus.Logging;

namespace ECom.Gateway.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VoucherController : BaseController
    {
        private readonly IMessageSession messageSession;
        private readonly ILog log = LogManager.GetLogger(typeof(VoucherController));
        public VoucherController(IMessageSession messageSession)
        {
            this.messageSession = messageSession;
        }

        [HttpGet]
        [EnableCors]
        public async Task<IActionResult> GetAllVoucher()
        {
            log.Info("Received request");
            var message = new GetAllVoucherCommand();
            try
            {
                var response = await this.messageSession.Request<Response<VoucherDto>>(message);
                log.Info($"Message sent, received: {response.responseData}");
                return ReturnWithStatus<VoucherDto>(response);
            }
            catch (OperationCanceledException ex)
            {
                log.Info($"Message sent, but {ex}");
                Request.HttpContext.Response.StatusCode = (int)HttpStatusCode.RequestTimeout;
                return StatusCode(500);
            }
        }

        [HttpPost]
        [EnableCors]
        public async Task<IActionResult> CreateVoucher(VoucherDto newVoucher)
        {
            if (newVoucher == null)
            {
                return BadRequest();
            }
            try
            {
                var message = new CreateVoucherCommand() { Voucher = newVoucher };
                var response = await this.messageSession.Request<Response<VoucherDto>>(message);
                return ReturnWithStatus<VoucherDto>(response);
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpPatch]
        [EnableCors]
        [Route("{code}")]
        public async Task<IActionResult> UpdateVoucher(string code, VoucherDto newVoucher)
        {

            if (newVoucher == null)
            {
                return BadRequest();
            }
            try
            {
                var message = new UpdateVoucherCommand() { Voucher = newVoucher, Code = code };
                var response = await this.messageSession.Request<Response<VoucherDto>>(message);
                return ReturnWithStatus<VoucherDto>(response);
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpDelete]
        [EnableCors]
        [Route("{code}")]
        public async Task<IActionResult> DeleteVoucher(string code)
        {
            if (code == null)
            {
                return BadRequest();
            }
            try
            {
                var message = new DeleteVoucherCommand() { Code = code };
                var response = await this.messageSession.Request<Response<string>>(message);
                return Ok();
            }
            catch
            {
                return StatusCode(500);
            }
        }
    }
}
