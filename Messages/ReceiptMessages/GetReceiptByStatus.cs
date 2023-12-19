using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messages.ReceiptMessages
{
    public class GetReceiptByStatus : ICommand
    {
        public char Status {  get; set; }
    }
}
