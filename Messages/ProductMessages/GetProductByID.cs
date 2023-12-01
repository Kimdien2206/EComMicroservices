using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messages.ProductMessages
{
    public class GetProductByID : ICommand
    {
        public string productSlug;
    }
}
