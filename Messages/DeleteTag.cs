using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messages
{
    public class DeleteTag : ICommand
    {
        public int Id { get; set; } 
    }
}
