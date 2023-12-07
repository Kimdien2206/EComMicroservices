using Dto.ProductDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messages.DiscountMessages
{
    public class UpdateDiscount : ICommand
    {
        public int id { get; set; }
        public DiscountDto discount { get; set; }
    }
}
