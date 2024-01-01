namespace Dto.ForecastDto
{
    public class ForecastDetailDto
    {
        public int Id { get; set; }
        public DateOnly date { get; set; }

        public int TotalSold { get; set; }

        public int ForecastId { get; set; }
    }
}
