namespace Dto.OrderDto
{
    public class OrderDetailDto
    {
        public int Id { get; set; }

        public int OrderId { get; set; }

        public int Quantity { get; set; }

        public int ItemId { get; set; }

        public int Price { get; set; }

        public ProductDto.ProductDto? Product { get; set; }

        public ProductDto.ProductItemDto? ProductItem { get; set; }
    }
}
