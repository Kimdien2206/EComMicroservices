using AutoMapper;
using Dto.ProductDto;
using ECom.Gateway.Models;
using Messages;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using NServiceBus.Logging;
using System.Net;

namespace ECom.Gateway.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DiscountController : BaseController
    {
        private readonly IMessageSession messageSession;
        private readonly ILog log = LogManager.GetLogger(typeof(DiscountController));
        private readonly IMapper _mapper;
        public DiscountController(IMessageSession messageSession, IMapper mapper)
        {
            this.messageSession = messageSession;
            this._mapper = mapper;
        }
        [HttpGet]
        [EnableCors]
        public async Task<IActionResult> GetAllDiscount()
        {
            //var cancellationTokenSource = new CancellationTokenSource();
            //cancellationTokenSource.CancelAfter(TimeSpan.FromSeconds(5));
            log.Info("Received request");
            var message = new GetAllDiscount();
            try
            {
                var response = await this.messageSession.Request<Response<DiscountDto>>(message);
                log.Info($"Message sent, received: {response.responseData}");
                return ReturnWithStatus<Discount, DiscountDto>(response);
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
