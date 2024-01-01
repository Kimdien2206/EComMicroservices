using AutoMapper;
using Dto.AuthDto;
using ECom.Services.Auth.Data;
using ECom.Services.Auth.Models;
using ECom.Services.Auth.Service;
using ECom.Services.Auth.Utility;
using Messages;
using Messages.AuthMessages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NServiceBus.Logging;

namespace ECom.Services.Auth.Handler
{
    public class AuthHandler :
        IHandleMessages<LoginMessage>,
        IHandleMessages<MailSentEvent>,
        IHandleMessages<ResetPasswordCommand>
    {
        private IMapper mapper;
        static ILog log = LogManager.GetLogger<AuthHandler>();
        private IConfiguration configuration;
        public AuthHandler()
        {
            configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .Build();
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
            });
            this.mapper = config.CreateMapper();
        }

        public async Task Handle(LoginMessage message, IMessageHandlerContext context)
        {
            var response = new Response<AuthDto>();

            string email = message.loginUser.email;
            string password = message.loginUser.password;
            var loginAccount = DataAccess.Ins.DB.Accounts.FirstOrDefault(u => u.Email == email);

            if (loginAccount == null)
            {
                response.ErrorCode = 404;
            }
            else
            {
                try
                {
                    log.Info($"account password hashed: {loginAccount.Password}");
                    log.Info($"password: {password}");
                    if (BCrypt.Net.BCrypt.Verify(password, loginAccount.Password))
                    {
                        response.ErrorCode = 200;

                        User userInfo = DataAccess.Ins.DB.Users.Where(u => u.Email == email).Include(u => u.Account).First();

                        userInfo.LoggedDate = DateTime.Now;

                        AuthDto Dto = new AuthDto();
                        Dto.userInfo = mapper.Map<UserDto>(userInfo);
                        Dto.userInfo.IsAdmin = userInfo.Account.IsAdmin;

                        Dto.AccessToken = JwtService.GenerateJSONWebToken(configuration["Jwt:Issuer"], configuration["Jwt:Key"]);

                        log.Info($"AccessToken: {Dto.AccessToken}");
                        List<AuthDto> responseData = new List<AuthDto>() { Dto };

                        response.responseData = responseData;
                        DataAccess.Ins.DB.SaveChanges();
                    }
                    else
                    {
                        response.ErrorCode = 403;
                    }
                }
                catch (Exception e)
                {
                    log.Error($"Error message: {e.Message}");
                    log.Error(e.StackTrace);

                    response.ErrorCode = 500;
                }

            }

            await context.Reply(response);
        }

        public Task Handle(MailSentEvent message, IMessageHandlerContext context)
        {
            log.Info($"{message.Email} + {message.Code}");

            Authenticator authenticator = new Authenticator()
            {
                Code = message.Code,
                Email = message.Email,
                Expiration = DateTime.Now.AddMinutes(30)
            };

            DataAccess.Ins.DB.Authenticators.Add(authenticator);

            DataAccess.Ins.DB.SaveChanges();

            return Task.CompletedTask;
        }

        public async Task Handle(ResetPasswordCommand message, IMessageHandlerContext context)
        {
            var vertificationCodes = DataAccess.Ins.DB.Authenticators.Where(auth => auth.Email == message.Email).ToList();

            var response = new Response<string>();

            if (vertificationCodes.Count > 0)
            {
                bool isCodeValid = false;

                foreach (var vertificationCode in vertificationCodes)
                {
                    if (vertificationCode.Code == message.Code && vertificationCode.Expiration > DateTime.Now)
                    {
                        isCodeValid = true;

                        break;
                    }
                }

                if (isCodeValid)
                {
                    response.ErrorCode = 200;
                    response.responseData = new List<string>() { "OK" };

                    Account? account = DataAccess.Ins.DB.Accounts.Where(acc => acc.Email == message.Email).FirstOrDefault();

                    if (account != null)
                    {
                        account.Password = message.NewPassword;
                        // update password to new password 
                        DataAccess.Ins.DB.Accounts.Update(account);
                        // delete all the vertification code relate to that email
                        DataAccess.Ins.DB.Authenticators.RemoveRange(vertificationCodes);
                        DataAccess.Ins.DB.SaveChanges();
                    }
                }
                else
                {
                    response.ErrorCode = 400;
                    response.responseData = new List<string>() { "Vertification code is wrong or out of date" };
                }

            }
            else
            {
                response.ErrorCode = 400;
                response.responseData = new List<string>() { "Vertification code is not exist or wrong" };
            }

            await context.Reply(response);
        }
    }
}
