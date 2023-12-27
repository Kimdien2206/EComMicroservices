using Dto.CartDto;
using Messages;
using Messages.CartMessages;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using NServiceBus.Logging;

namespace ECom.Gateway.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CartController : BaseController
    {
        private readonly IMessageSession messageSession;
        private readonly ILog log = LogManager.GetLogger(typeof(CartController));
        public CartController(IMessageSession messageSession)
        {
            this.messageSession = messageSession;
        }

        [HttpGet]
        [EnableCors]
        [Route("{phoneNumber}")]
        public async Task<IActionResult> GetCartByPhonenumber(string phoneNumber)
        {
            var message = new GetCartByUser() { PhoneNumber = phoneNumber };
            try
            {
                var response = await this.messageSession.Request<Response<CartDto>>(message);
                log.Info($"Message sent, received: {response.responseData}");
                return ReturnWithStatus(response);
            }
            catch (OperationCanceledException ex)
            {
                log.Info($"Message sent, but {ex}");
                return StatusCode(500);
            }
        }

        [HttpPost]
        [EnableCors]
        public async Task<IActionResult> CreateCart(CreateCartDto createCartDto)
        {
            if (createCartDto == null)
            {
                return BadRequest();
            }
            var message = new CreateCart() { newCart = createCartDto };
            try
            {
                var response = await this.messageSession.Request<Response<string>>(message);
                log.Info($"Message sent, received: {response.responseData}");
                return ReturnWithStatus(response);
            }
            catch (OperationCanceledException ex)
            {
                log.Info($"Message sent, but {ex}");
                return StatusCode(500);
            }
        }

        [HttpPatch]
        [EnableCors]
        [Route("{phoneNumber}")]
        public async Task<IActionResult> UpdateCart(string phoneNumber, UpdateCartDto updateCartDto)
        {
            if (updateCartDto == null)
            {
                return BadRequest();
            }
            var message = new UpdateQuantity() { PhoneNumber = phoneNumber, Details = updateCartDto.Details };
            try
            {
                var response = await this.messageSession.Request<Response<string>>(message);
                log.Info($"Message sent, received: {response.responseData}");
                return ReturnWithStatus(response);
            }
            catch (OperationCanceledException ex)
            {
                log.Info($"Message sent, but {ex}");
                return StatusCode(500);
            }
        }

        [HttpDelete]
        [EnableCors]
        [Route("{phoneNumber}")]
        public async Task<IActionResult> Delete(string phoneNumber, DeleteCartDto deleteCartDto)
        {
            if (deleteCartDto == null)
            {
                return BadRequest();
            }
            var message = new RemoveCart() { CartId = phoneNumber, IsDeleteAll = deleteCartDto.IsDeleteAll, RemoveDetails = deleteCartDto.Details };
            try
            {
                var response = await this.messageSession.Request<Response<string>>(message);
                log.Info($"Message sent, received: {response.responseData}");
                return ReturnWithStatus(response);
            }
            catch (OperationCanceledException ex)
            {
                log.Info($"Message sent, but {ex}");
                return StatusCode(500);
            }
        }
    }
}
