using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messages.DiscountMessages
{
    public class GetProductOfDiscount : ICommand
    {
        public int Id { get; set; }
    }
}
