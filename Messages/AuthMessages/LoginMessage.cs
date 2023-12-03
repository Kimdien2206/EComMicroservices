using Dto.AuthDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messages.AuthMessages
{
    public class LoginMessage : ICommand
    {
        public LoginDto loginUser { get; set; }
    }
}
