using Dto.ReceiptDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messages.ReceiptMessages
{
    public class CreateReceipt : ICommand
    {
        public ReceiptCreateDto newReceipt { get; set; }
    }
}
