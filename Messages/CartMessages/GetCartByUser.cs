using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messages.CartMessages
{
    public class GetCartByUser : ICommand
    {
        public string PhoneNumber { get; set; }
    }
}
