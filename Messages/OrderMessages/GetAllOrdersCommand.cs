namespace Messages.OrderMessages
{
    public class GetAllOrdersCommand : ICommand
    {
        public string SagaId { get; set; }
    }
}
