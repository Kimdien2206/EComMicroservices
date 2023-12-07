using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messages.ProductMessages
{
    public class GetProductByItemID : ICommand
    {
        public int ItemId { get; set; }
    }
}
