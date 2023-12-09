using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messages.ReceiptMessages
{
    public class PaidReceipt : ICommand
    {
        public int ReceiptId { get; set; } 
    }
}
