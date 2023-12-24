namespace Messages.ForecastMessage
{
    public class GetForecastByProductId : ICommand
    {
        public int Id { get; set; }
    }
}
