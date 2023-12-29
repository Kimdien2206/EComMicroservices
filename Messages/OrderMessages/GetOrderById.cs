using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messages.OrderMessages
{
    public class GetOrderById : ICommand
    {
        public int Id { get; set; }
    }
}
