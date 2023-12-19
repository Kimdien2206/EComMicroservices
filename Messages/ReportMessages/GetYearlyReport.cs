using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messages.ReportMessages
{
    public class GetYearlyReport : ICommand
    {
        public DateOnly Year { get; set; }
    }
}
