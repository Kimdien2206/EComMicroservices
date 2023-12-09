using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dto.ReportDto
{
    public class YearlyReport
    {
        public DateOnly Year { get; set; }

        public int Income { get; set; }

        public int Outcome { get; set; }

        public int Profit { get; set; }

        public int SoldQuantity { get; set; }

        public virtual ICollection<MonthlyReport> MonthlyReports { get; set; } = new List<MonthlyReport>();
    }
}
