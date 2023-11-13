using Dto.ProductDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messages
{
    public class GetProductByIDRes : IMessage
    {
        public ProductDto product { get; set; }
    }
}
