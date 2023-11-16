using Dto.ProductDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messages
{
    public class Response<T> : IMessage
    {
        public int ErrorCode { get; set; }
        public IEnumerable<T>? responseData { get; set; }
    }
}
