using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Dto.AuthDto;
using Ecom.Services.Mailer.Service;
using Messages;
using Messages.AuthMessages;
using Messages.MailerMessage;
using NServiceBus.Logging;

namespace ECom.Services.Mailer.Handler
{
    public class MailHandler : IHandleMessages<SendMailMessage>
    {
        static MailService service = new MailService();
        static ILog log = LogManager.GetLogger<MailHandler>();

        public async Task Handle(SendMailMessage message, IMessageHandlerContext context)
        {
            log.Info("Sending mail verification code to mail " +  message.Email);
            try 
            { 
                int verificationCode = MailService.GenerateVerificationCode();

                MailService.SendVerificationEmail(message.Email, verificationCode);

                MailSentEvent mailSentEvent = new MailSentEvent() { Email = message.Email, Code = verificationCode };

                await context.Publish(mailSentEvent);

            } catch (Exception ex) 
            { 
                log.Error(ex.Message);
            }
        }
    }
}
