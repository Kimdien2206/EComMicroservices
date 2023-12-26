using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messages.UserMessages
{
    public class UserLoggedIn : IEvent
    {
        public string PhoneNumber { get; set; }
    }
}
