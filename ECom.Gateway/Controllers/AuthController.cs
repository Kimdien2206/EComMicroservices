using AutoMapper;
using Dto.AuthDto;
using ECom.Gateway.Models;
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
        private readonly IMapper _mapper;
        public AuthController(IMessageSession messageSession, IMapper mapper)
        {
            this.messageSession = messageSession;
            this._mapper = mapper;
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
                    return ReturnWithStatus<Product, AuthDto>(response);
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
