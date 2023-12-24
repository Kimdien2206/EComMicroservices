using Dto.ReportDto;

namespace SagaData.Forecast
{
    public class ForecastSagaData : ContainSagaData
    {
        public string SagaId { get; set; }
        public List<int> Products { get; set; }

        public List<DailyReportDetailDto> DailyReports { get; set; }
    }
}
