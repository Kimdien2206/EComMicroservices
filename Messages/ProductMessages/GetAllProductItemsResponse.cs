using Dto.ProductDto;

namespace Messages.ProductMessages
{
    public class GetAllProductItemsResponse : IMessage
    {
        public string SagaId { get; set; }
        public List<ProductItemDto> ProductItems { get; set; }
    }
}
