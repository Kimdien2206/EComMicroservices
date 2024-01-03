namespace Messages.ProductMessages
{
    public class GetAllProductIdsResponse : IMessage
    {
        public string SagaId { get; set; }

        public List<int> ProductIds { get; set; }
    }
}
