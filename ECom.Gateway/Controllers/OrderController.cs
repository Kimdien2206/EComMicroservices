using AutoMapper;
//using Dto.OrderDto;
using Messages;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using NServiceBus.Logging;
using System.Net;

namespace ECom.Gateway.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : BaseController
    {
        private readonly IMessageSession messageSession;
        private readonly ILog log = LogManager.GetLogger(typeof(DiscountController));
        private readonly IMapper _mapper;

        public OrderController(IMessageSession messageSession, IMapper mapper)
        {
            this.messageSession = messageSession;
            this._mapper = mapper;
        }

        //[HttpGet]
        //[EnableCors]
        //public async Task<IActionResult> GetAllOrders()
        //{
        //    //var cancellationTokenSource = new CancellationTokenSource();
        //    //cancellationTokenSource.CancelAfter(TimeSpan.FromSeconds(5));
        //    log.Info("Received request");
        //    var message = new GetAllOrder();
        //    try
        //    {
        //        var response = await this.messageSession.Request<Response<OrderDto>>(message);
        //        log.Info($"Message sent, received: {response.responseData}");
        //        return ReturnWithStatus<Order, OrderDto>(response);
        //    }
        //    catch (OperationCanceledException ex)
        //    {
        //        log.Info($"Message sent, but {ex}");
        //        Request.HttpContext.Response.StatusCode = (int)HttpStatusCode.RequestTimeout;
        //        return StatusCode(500);
        //    }
        //}
    }
}
