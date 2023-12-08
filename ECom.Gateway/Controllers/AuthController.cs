using Dto.AuthDto;
using Messages;
using Messages.AuthMessages;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using NServiceBus.Logging;

namespace ECom.Gateway.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : BaseController
    {
        private readonly IMessageSession messageSession;
        private readonly ILog log = LogManager.GetLogger(typeof(CollectionController));
        public AuthController(IMessageSession messageSession)
        {
            this.messageSession = messageSession;
        }

        [HttpPost]
        [EnableCors]
        [Route("login")]
        public async Task<IActionResult> Login(LoginDto loginUser)
        {
            if (loginUser.email == null || loginUser.password == null)
            {
                return BadRequest();
            }
            else
            {
                try
                {
                    var message = new LoginMessage() { loginUser = loginUser };
                    var response = await messageSession.Request<Response<AuthDto>>(message);
                    return ReturnWithStatus(response);
                }
                catch (Exception ex)
                {
                    log.Info($"Error occurred: {ex}");
                    return StatusCode(500);
                }
            }
        }
    }
}
