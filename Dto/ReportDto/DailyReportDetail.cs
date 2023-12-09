
namespace Dto.ReportDto
{
    public class DailyReportDetail
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public int Quantity { get; set; }

        public DateOnly Date { get; set; }

        public virtual DailyReport DateNavigation { get; set; } = null!;
    }
}
