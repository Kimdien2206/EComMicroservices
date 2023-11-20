using AutoMapper;
using Dto.AuthDto;
using ECom.Services.Auth.Data;
using ECom.Services.Auth.Models;
using ECom.Services.Auth.Utility;
using Messages;
using Microsoft.EntityFrameworkCore;
using NServiceBus.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ECom.Services.Auth.Handler
{
    public class AuthHandler : 
        IHandleMessages<LoginMessage>
    {
        private IMapper mapper;
        static ILog log = LogManager.GetLogger<AuthHandler>();

        public AuthHandler()
        {
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
            Account loginAccount = DataAccess.Ins.DB.Accounts.First(u => u.Email == email);

            //int salt = 12;
            

            // derive a 256-bit subkey (use HMACSHA256 with 100,000 iterations)
            //string hashed = BCrypt.Net.BCrypt.HashPassword(password);

            //Console.WriteLine($"Hashed: {hashed}");

            if (loginAccount == null)
            {
                response.ErrorCode = 404;
            }
            else
            {
                if(BCrypt.Net.BCrypt.Verify(password, loginAccount.Password))
                {
                    response.ErrorCode = 200;

                    User userInfo = DataAccess.Ins.DB.Users.Where(u => u.Email == email).Include(u => u.Account).First();

                    userInfo.LoggedDate = DateTime.Now;

                    AuthDto Dto = new AuthDto();
                    Dto.userInfo = mapper.Map<UserDto>(userInfo);
                    Dto.userInfo.IsAdmin = userInfo.Account.IsAdmin;
                    
                    List<AuthDto> responseData = new List<AuthDto>() { Dto };
                    response.responseData = responseData;

                    DataAccess.Ins.DB.SaveChanges();
                }
                else
                {
                    response.ErrorCode = 403;

                }
            }


            await context.Reply(response);
        }
    }
}
