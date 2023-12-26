using AutoMapper;
using Dto.AuthDto;
using ECom.Services.Auth.Data;
using ECom.Services.Auth.Models;
using ECom.Services.Auth.Utility;
using Messages;
using Messages.AuthMessages;
using Messages.MailerMessage;
using Messages.UserMessages;
using NServiceBus.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECom.Services.Auth.Handler
{
    public class AccountHandler : 
        IHandleMessages<ResetCodeCommand>,
        IHandleMessages<GetAllUser>,
        IHandleMessages<UpdateUser>,
        IHandleMessages<UserLoggedIn>
    {
        private IMapper mapper;
        static ILog log = LogManager.GetLogger<AccountHandler>();

        public AccountHandler()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
            });
            this.mapper = config.CreateMapper();
        }

        public async Task Handle(ResetCodeCommand message, IMessageHandlerContext context)
        {
            log.Info($"Handle reset password command for {message.Email}");
            Account? loginAccount = DataAccess.Ins.DB.Accounts.FirstOrDefault(u => u.Email == message.Email);
            var response = new Response<string>();

            if (loginAccount != null)
            {
                SendMailMessage sendMail = new SendMailMessage() { Email = loginAccount.Email };
                //log.Info(context.Send(sendMail).IsCompletedSuccessfully.ToString());
                var sendRespond = context.Send(sendMail);
                log.Info($"Route destination {sendRespond.Status.ToString()}");
                log.Info($"Route destination {sendRespond.IsCompletedSuccessfully}");
            } else
            {
                log.Warn("Reset password with user does not exist in system.");
            }

            response.responseData = new List<string>() { "OK" };
            response.ErrorCode = 200;

            await context.Reply(response);
        }

        public async Task Handle(GetAllUser message, IMessageHandlerContext context)
        {
            log.Info("Received messages, getting user list");
            List<User> users = DataAccess.Ins.DB.Users.ToList();
            var response = new Response<UserDto>();


            response.responseData = users.Select(emp => mapper.Map<UserDto>(emp));
            response.ErrorCode = 200;

            await context.Reply(response);
        }

        public async Task Handle(UpdateUser message, IMessageHandlerContext context)
        {
            var response = new Response<UserDto>();
            if (message.PhoneNumber == null)
            {
                log.Info("Received message, but missing phone number");
                response.ErrorCode = 400;
            }
            else
            {
                User updateUser = DataAccess.Ins.DB.Users.First(u => u.PhoneNumber == message.PhoneNumber);
                if (updateUser == null)
                {
                    response.ErrorCode = 404;
                }
                else
                {
                    updateUser.Firstname = message.NewInfo.Firstname;
                    updateUser.Lastname = message.NewInfo.Lastname;
                    updateUser.Address = message.NewInfo.Address;
                    updateUser.Avatar = message.NewInfo.Avatar;
                    try
                    {
                        DataAccess.Ins.DB.SaveChanges();
                        log.Info($"User logged in at {DateTime.Now}");
                        response.ErrorCode = 200;
                    }
                    catch (Exception ex)
                    {
                        log.Info(ex.ToString());
                        response.ErrorCode = 500;
                    }
                }
            }
            await context.Reply(response);
        }

        public Task Handle(UserLoggedIn message, IMessageHandlerContext context)
        {
            if (message.PhoneNumber == null)
            {
                log.Info("Received message, but missing phone number");
                return Task.FromException(new ArgumentException());
            }
            else
            {
                User loggedInUser = DataAccess.Ins.DB.Users.First(u => u.PhoneNumber == message.PhoneNumber);
                loggedInUser.LoggedDate = DateTime.Now;

                try
                {
                    DataAccess.Ins.DB.SaveChanges();
                    log.Info($"User logged in at {DateTime.Now}");
                }
                catch (Exception ex)
                {
                    log.Info(ex.ToString());
                }
                return Task.CompletedTask;
            }
        }
    }
}
