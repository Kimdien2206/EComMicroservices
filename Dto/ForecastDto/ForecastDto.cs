namespace Dto.ForecastDto
{
    public class ForecastDto
    {
        public int Id { get; set; }
        public DateOnly LastUpdated { get; set; }

        public int ProductId { get; set; }
    }
}
