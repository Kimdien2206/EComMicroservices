using Dto.ReportDto;

namespace Messages.ReportMessages
{
    public class GetAllDailyDetailReportSaga : IMessage
    {
        public string SagaId { get; set; }
        public List<DailyReportDetailDto> Forecasts { get; set; }
    }
}
