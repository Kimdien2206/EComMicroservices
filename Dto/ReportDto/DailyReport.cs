using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dto.ReportDto
{
    public class DailyReport
    {
        public DateOnly Date { get; set; }

        public int Income { get; set; }

        public int Outcome { get; set; }

        public int Profit { get; set; }

        public int SoldQuantity { get; set; }

        public DateOnly Month { get; set; }

        public virtual ICollection<DailyReportDetail> Details { get; set; } = null!;
    }
}
