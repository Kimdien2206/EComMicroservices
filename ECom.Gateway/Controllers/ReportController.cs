using System.Net;
using Dto.ReportDto;
using Messages;
using Messages.ReportMessages;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using NServiceBus.Logging;

namespace ECom.Gateway.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReportController : BaseController
    {
        private readonly IMessageSession messageSession;
        private readonly ILog log = LogManager.GetLogger(typeof(ReportController));

        public ReportController(IMessageSession messageSession)
        {
            this.messageSession = messageSession;
        }

        [HttpGet]
        [EnableCors]
        [Route("yearly/{year}")]
        public async Task<IActionResult> GetYearlyReport(string year)
        {
            log.Info("Received request");
            if (year == null)
            {
                return BadRequest();
            }
            try
            {
                DateOnly requestYear = DateOnly.Parse(year);
                var message = new GetYearlyReport() { Year = requestYear };

                var response = await this.messageSession.Request<Response<YearlyReportDto>>(message);
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
