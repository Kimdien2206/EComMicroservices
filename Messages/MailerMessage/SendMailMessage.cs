using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messages.MailerMessage
{
    public class SendMailMessage : ICommand
    {
        public required string Email { get; set; }
    }
}
