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
    public class YearlyReportDto
    {
        public DateOnly Year { get; set; }

        public long Income { get; set; }

        public long Outcome { get; set; }

        public long Profit { get; set; }

        public int SoldQuantity { get; set; }

        public virtual ICollection<MonthlyReportDto> MonthlyReports { get; set; } = new List<MonthlyReportDto>();
    }
}
