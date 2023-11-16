using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messages
{
    public class ProductSold : IEvent
    {
        public List<int> Id { get; set; }
    }
}
