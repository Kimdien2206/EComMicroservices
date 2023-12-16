using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messages.ReceiptMessages
{
    public class ReceiptPaid : IEvent
    {
        public DateOnly PaidDate { get; set; }
        public long Income { get; set; }

    }
}
