﻿using Dto.AuthDto;
using ECom.Gateway.Utils;
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
                    return ReturnWithStatus<AuthDto>(response);
                }
                catch (Exception ex)
                {
                    log.Info($"Error occurred: {ex}");
                    return StatusCode(500);
                }
            }
        }

        [HttpPost]
        [EnableCors]
        [Route("register")]
        public async Task<IActionResult> Register(RegisterDto registerDto)
        {
            log.Info("Register Dto \n" + Converter.ConvertToJson(registerDto));
            if (registerDto.email == null || registerDto.password == null || registerDto.email != registerDto.user.Email)
            {
                return BadRequest();
            }
            else
            {
                try
                {
                    var message = new RegisterCommand() { Register = registerDto };
                    var response = await messageSession.Request<Response<string>>(message);
                    return ReturnWithStatus<string>(response);
                }
                catch (Exception ex)
                {
                    log.Info($"Error occurred: {ex}");
                    log.Error(ex.StackTrace);
                    return StatusCode(500);
                }
            }
        }

        [HttpPost]
        [EnableCors]
        [Route("reset-code")]
        public async Task<IActionResult> SendResetCode(ResetCodeDto forgotPassworDto)
        {
            if (forgotPassworDto.email == null)
            {
                return BadRequest();
            }
            else
            {
                try
                {
                    var message = new ResetCodeCommand() { Email = forgotPassworDto.email };
                    var respond = await messageSession.Request<Response<string>>(message);
                    return ReturnWithStatus<string>(respond);
                }
                catch (Exception ex)
                {
                    log.Info($"Error occurred: {ex}");
                    return StatusCode(500);
                }
            }
        }

        [HttpPost]
        [EnableCors]
        [Route("reset-password")]
        public async Task<IActionResult> verifyCodeAndResetPassword(ResetPasswordDto resetPasswordDto)
        {
            if (resetPasswordDto.Email == null)
            {
                return BadRequest();
            }
            else
            {
                try
                {
                    var message = new ResetPasswordCommand() { Email = resetPasswordDto.Email, Code = resetPasswordDto.Code, NewPassword = resetPasswordDto.Password };
                    var respond = await messageSession.Request<Response<string>>(message);
                    return ReturnWithStatus<string>(respond);
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
