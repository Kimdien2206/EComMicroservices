namespace Messages.ForecastMessage
{
    public class TrainForecastCommand : ICommand
    {
        public string SagaId { get; set; }
    }
}
