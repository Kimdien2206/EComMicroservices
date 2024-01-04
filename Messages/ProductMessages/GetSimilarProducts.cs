using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messages.ProductMessages
{
    public class GetSimilarProducts : ICommand
    {
        public int Id { get; set; }
    }
}
