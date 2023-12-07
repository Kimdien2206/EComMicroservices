using AutoMapper;
using Dto.ProductDto;
using ECom.Gateway.Models;
using Messages;
using Messages.DiscountMessages;
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
                return ReturnWithStatus<DiscountDto>(response);
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
        public async Task<IActionResult> CreateDiscount(Discount newDiscount)
        {
            if (newDiscount == null)
            {
                return BadRequest();
            }
            try
            {
                DiscountDto newDiscountDto = _mapper.Map<DiscountDto>(newDiscount);
                var message = new CreateDiscount() { discount = newDiscountDto };
                var response = await this.messageSession.Request<Response<DiscountDto>>(message);
                return ReturnWithStatus<DiscountDto>(response);
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpPatch]
        [EnableCors]
        [Route("{id}")]
        public async Task<IActionResult> UpdateDiscount(string id, Discount newDiscount)
        {
            int discountID = Int32.Parse(id);
            if (newDiscount == null || discountID == 0)
            {
                return BadRequest();
            }
            try
            {
                DiscountDto newDiscountDto = _mapper.Map<DiscountDto>(newDiscount);
                var message = new UpdateDiscount() { discount = newDiscountDto, id = discountID };
                var response = await this.messageSession.Request<Response<DiscountDto>>(message);
                return ReturnWithStatus<DiscountDto>(response);
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpDelete]
        [EnableCors]
        [Route("{id}")]
        public async Task<IActionResult> DeleteDiscount(string id)
        {
            int discountID = Int32.Parse(id);
            if (discountID == 0)
            {
                return BadRequest();
            }
            try
            {
                var message = new DeleteDiscount() { Id = discountID };
                var response = await this.messageSession.Request<Response<DiscountDto>>(message);
                return ReturnWithStatus<DiscountDto>(response);
            }
            catch
            {
                return StatusCode(500);
            }
        }
    }
}
