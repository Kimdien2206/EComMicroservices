using AutoMapper;
using Dto.AuthDto;
using ECom.Services.Auth.Data;
using ECom.Services.Auth.Models;
using ECom.Services.Auth.Utility;
using Messages;
using Messages.AuthMessages;
using Messages.MailerMessage;
using NServiceBus.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECom.Services.Auth.Handler
{
    public class AccountHandler : IHandleMessages<ResetCodeCommand>
    {
        static ILog log = LogManager.GetLogger<AccountHandler>();

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
    }
}
