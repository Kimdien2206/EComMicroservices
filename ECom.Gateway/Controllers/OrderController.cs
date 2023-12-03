using AutoMapper;
using Dto.OrderDto;
using ECom.Gateway.Models;
using Messages;
using Messages.OrderMessages;
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

        [HttpGet]
        [EnableCors]
        public async Task<IActionResult> GetAllOrders()
        {

            log.Info("Received request");
            var message = new GetAllOrder();
            try
            {
                var response = await this.messageSession.Request<Response<OrderDto>>(message);
                log.Info($"Message sent, received: {response.responseData}");
                return ReturnWithStatus<Order, OrderDto>(response);
            }
            catch (OperationCanceledException ex)
            {
                log.Info($"Message sent, but {ex}");
                Request.HttpContext.Response.StatusCode = (int)HttpStatusCode.RequestTimeout;
                return StatusCode(500);
            }
        }

        [HttpGet]
        [Route("pending")]
        public async Task<IActionResult> GetPendingOrders()
        {

            log.Info("Received request");
            var message = new GetOrderByStatus() { Status = '0' };
            try
            {
                var response = await this.messageSession.Request<Response<OrderDto>>(message);
                log.Info($"Message sent, received: {response.responseData}");
                return ReturnWithStatus<Order, OrderDto>(response);
            }
            catch (OperationCanceledException ex)
            {
                log.Info($"Message sent, but {ex}");
                Request.HttpContext.Response.StatusCode = (int)HttpStatusCode.RequestTimeout;
                return StatusCode(500);
            }
        }
        
        [HttpGet]
        [Route("complete")]
        public async Task<IActionResult> GetCompletedOrders()
        {

            log.Info("Received request");
            var message = new GetOrderByStatus() { Status = '2' };
            try
            {
                var response = await this.messageSession.Request<Response<OrderDto>>(message);
                log.Info($"Message sent, received: {response.responseData}");
                return ReturnWithStatus<Order, OrderDto>(response);
            }
            catch (OperationCanceledException ex)
            {
                log.Info($"Message sent, but {ex}");
                Request.HttpContext.Response.StatusCode = (int)HttpStatusCode.RequestTimeout;
                return StatusCode(500);
            }
        }
       
        [HttpGet]
        [Route("canceled")]
        public async Task<IActionResult> GetCanceledOrders()
        {

            log.Info("Received request");
            var message = new GetOrderByStatus() { Status = '3' };
            try
            {
                var response = await this.messageSession.Request<Response<OrderDto>>(message);
                log.Info($"Message sent, received: {response.responseData}");
                return ReturnWithStatus<Order, OrderDto>(response);
            }
            catch (OperationCanceledException ex)
            {
                log.Info($"Message sent, but {ex}");
                Request.HttpContext.Response.StatusCode = (int)HttpStatusCode.RequestTimeout;
                return StatusCode(500);
            }
        }
        
        [HttpGet]
        [Route("delivering")]
        public async Task<IActionResult> GetDeliveringOrders()
        {

            log.Info("Received request");
            var message = new GetOrderByStatus() { Status = '1' };
            try
            {
                var response = await this.messageSession.Request<Response<OrderDto>>(message);
                log.Info($"Message sent, received: {response.responseData}");
                return ReturnWithStatus<Order, OrderDto>(response);
            }
            catch (OperationCanceledException ex)
            {
                log.Info($"Message sent, but {ex}");
                Request.HttpContext.Response.StatusCode = (int)HttpStatusCode.RequestTimeout;
                return StatusCode(500);
            }
        }

        [HttpPatch]
        [Route("deliver/{id}")]
        public async Task<IActionResult> DeliveryOrder(string Id)
        {
            log.Info("Received request");

            if(Id == null)
            {
                return BadRequest();
            }
            var message = new UpdateOrderStatus() { Id = Id, Status = '1'};
            try
            {
                var response = await this.messageSession.Request<Response<OrderDto>>(message);
                log.Info($"Message sent, received: {response.responseData}");
                return ReturnWithStatus<Order, OrderDto>(response);
            }
            catch (OperationCanceledException ex)
            {
                log.Info($"Message sent, but {ex}");
                Request.HttpContext.Response.StatusCode = (int)HttpStatusCode.RequestTimeout;
                return StatusCode(500);
            }
        }
        
        [HttpPatch]
        [Route("complete/{id}")]
        public async Task<IActionResult> CompleteOrder(string Id)
        {
            log.Info("Received request");

            if(Id == null)
            {
                return BadRequest();
            }
            var message = new UpdateOrderStatus() { Id = Id, Status = '2'};
            try
            {
                var response = await this.messageSession.Request<Response<OrderDto>>(message);
                log.Info($"Message sent, received: {response.responseData}");
                return ReturnWithStatus<Order, OrderDto>(response);
            }
            catch (OperationCanceledException ex)
            {
                log.Info($"Message sent, but {ex}");
                Request.HttpContext.Response.StatusCode = (int)HttpStatusCode.RequestTimeout;
                return StatusCode(500);
            }
        }
        
        [HttpPatch]
        [Route("cancel/{id}")]
        public async Task<IActionResult> CancelOrder(string Id)
        {
            log.Info("Received request");

            if(Id == null)
            {
                return BadRequest();
            }
            var message = new UpdateOrderStatus() { Id = Id, Status = '3'};
            try
            {
                var response = await this.messageSession.Request<Response<OrderDto>>(message);
                log.Info($"Message sent, received: {response.responseData}");
                return ReturnWithStatus<Order, OrderDto>(response);
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
