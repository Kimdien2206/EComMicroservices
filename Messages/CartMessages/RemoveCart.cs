using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messages.CartMessages
{
    public class RemoveCart : ICommand
    {
        public int CartId { get; set; }
    }
}
