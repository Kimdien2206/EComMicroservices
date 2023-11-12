using Dto.ProductDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messages
{
    public class GetAllProductRes : IMessage
    {
        public IEnumerable<ProductDto> productDtos { get; set; }
    }
}
