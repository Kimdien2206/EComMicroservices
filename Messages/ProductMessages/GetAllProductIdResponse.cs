namespace Messages.ProductMessages
{
    public class GetAllProductIdResponse : IMessage
    {
        public string SagaId { get; set; }

        public List<int> ProductIds { get; set; }
    }
}
