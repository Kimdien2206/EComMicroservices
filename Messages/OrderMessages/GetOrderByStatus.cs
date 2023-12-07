using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messages.OrderMessages
{
    public class GetOrderByStatus : ICommand
    {
        public char Status { get; set; }
    }
}
