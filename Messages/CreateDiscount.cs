using Dto.ProductDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messages
{
    public class CreateDiscount : ICommand
    {
        public DiscountDto discount { get; set; }
    }
}
