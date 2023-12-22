using Dto.ProductDto;
using Messages.VoucherMessage;
using Messages;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using NServiceBus.Logging;
using System.Net;
using Dto.AuthDto;
using Messages.UserMessages;

namespace ECom.Gateway.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : BaseController
    {
        private readonly IMessageSession messageSession;
        private readonly ILog log = LogManager.GetLogger(typeof(UserController));
        public UserController(IMessageSession messageSession)
        {
            this.messageSession = messageSession;
        }

        [HttpGet]
        [EnableCors]
        public async Task<IActionResult> GetAllUser()
        {
            log.Info("Received request");
            var message = new GetAllUser();
            try
            {
                var response = await this.messageSession.Request<Response<UserDto>>(message);
                log.Info($"Message sent, received: {response.responseData}");
                return ReturnWithStatus<UserDto>(response);
            }
            catch (OperationCanceledException ex)
            {
                log.Info($"Message sent, but {ex}");
                Request.HttpContext.Response.StatusCode = (int)HttpStatusCode.RequestTimeout;
                return StatusCode(500);
            }
        }
        
        [HttpPatch]
        [EnableCors]
        [Route("logged-in/{phoneNumber}")]
        public async Task<IActionResult> UserLoggedIn(string phoneNumber)
        {
            log.Info("Received request");
            if(phoneNumber == null)
            {
                return BadRequest();
            }

            var message = new UserLoggedIn() { PhoneNumber = phoneNumber };
            try
            {
                await this.messageSession.Publish(message);
                log.Info($"Message sent");
                return Ok();
            }
            catch (Exception ex)
            {
                log.Info($"Message sent, but {ex}");
                return StatusCode(500);
            }
        }
        
        [HttpPut]
        [EnableCors]
        [Route("{phoneNumber}")]
        public async Task<IActionResult> UserLoggedIn(string phoneNumber, UserDto newInfo)
        {
            log.Info("Received request");
            if(newInfo == null || phoneNumber == null)
            {
                return BadRequest();
            }
            var message = new UpdateUser() { PhoneNumber = phoneNumber, NewInfo = newInfo };
            try
            {
                var response = await this.messageSession.Request<Response<UserDto>>(message);
                log.Info($"Message sent, received: {response.responseData}");
                return ReturnWithStatus<UserDto>(response);
            }
            catch (Exception ex)
            {
                log.Info($"Message sent, but {ex}");
                return StatusCode(500);
            }
        }
    }
}
