using Dto.ProductDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messages.ImportingMessages
{
    public class CreateImporting : ICommand
    {
        public ImportingDto newImporting { get; set; }
    }
}
