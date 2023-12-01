using Dto.ProductDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messages.TagMessages
{
    public class CreateTag : ICommand
    {
        public TagDto newTag { get; set; }
    }
}
