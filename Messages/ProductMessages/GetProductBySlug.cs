namespace Messages.ProductMessages
{
    public class GetProductBySlug : ICommand
    {
        public string ProductSlug { get; set; }
    }
}
