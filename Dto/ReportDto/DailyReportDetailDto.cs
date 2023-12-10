
namespace Dto.ReportDto
{
    public class DailyReportDetailDto
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public int Quantity { get; set; }

        public DateOnly Date { get; set; }

        public virtual DailyReportDto DateNavigation { get; set; } = null!;
    }
}
