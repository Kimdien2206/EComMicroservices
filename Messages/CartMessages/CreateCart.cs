using Dto.CartDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messages.CartMessages
{
    public class CreateCart : ICommand
    {
        public CartDto newCart { get; set; }
    }
}
