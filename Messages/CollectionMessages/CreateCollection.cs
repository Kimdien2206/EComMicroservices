using Dto.ProductDto;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messages.CollectionMessages
{
    public class CreateCollection : ICommand
    {
        public CollectionDto newCollection { get; set; }
    }
}
