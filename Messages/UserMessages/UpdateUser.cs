using Dto.AuthDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messages.UserMessages
{
    public class UpdateUser : ICommand
    {
        public string PhoneNumber { get; set; } 
        public UserDto NewInfo { get; set; }
    }
}
