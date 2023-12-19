
namespace Dto.ReportDto
{
    public class MonthlyReportDto
    {
        public DateOnly Month { get; set; }

        public long Income { get; set; }

        public long Outcome { get; set; }

        public long Profit { get; set; }

        public int SoldQuantity { get; set; }

        public DateOnly Year { get; set; }

        public virtual ICollection<DailyReportDto> DailyReports { get; set; } = new List<DailyReportDto>();
    }
}
