namespace Messages.ProductMessages
{
    public class GetAllProductItemsCommand : IMessage
    {
        public string SagaId { get; set; }
    }
}
