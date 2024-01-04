using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messages.ImportingMessages
{
    public class ImportingCreated : IEvent
    {
        public ulong TotalCost { get; set; }

        public DateOnly Date { get; set; }
    }
}
