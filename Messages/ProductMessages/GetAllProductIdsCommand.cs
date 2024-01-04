namespace Messages.ProductMessages
{
    public class GetAllProductIdsCommand : ICommand
    {
        public string SagaId { get; set; }
    }
}
