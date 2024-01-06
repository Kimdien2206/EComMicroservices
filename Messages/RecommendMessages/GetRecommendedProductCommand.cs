namespace Messages.RecommendMessages
{
    public class GetRecommendedProductCommand : ICommand
    {
        public int ProductId { get; set; }

        public List<int> ProductIds { get; set; }
    }
}
