
namespace Dto.ReportDto
{
    public class MonthlyReport
    {
        public DateOnly Month { get; set; }

        public int Income { get; set; }

        public int Outcome { get; set; }

        public int Profit { get; set; }

        public int SoldQuantity { get; set; }

        public DateOnly Year { get; set; }

        public virtual ICollection<DailyReport> DailyReports { get; set; } = new List<DailyReport>();
    }
}
