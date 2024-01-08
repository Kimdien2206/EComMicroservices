using Dto.OrderDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messages.OrderMessages
{
    public class OrderFinished : IEvent
    {
        public DateOnly Date { get; set; }

        public uint Quantity { get; set; }

        public int ProductId { get; set; }
    }
}
