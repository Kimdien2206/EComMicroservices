
namespace Dto.ProductDto
{
    public class ProductItemDto 
    {
        public int Id { get; set; }

        public string Color { get; set; } = null!;

        public string Size { get; set; } = null!;

        public int Quantity { get; set; }

        public string[]? Image { get; set; }

        public int ProductId { get; set; }

        public virtual ProductDto Product { get; set; } = null!;
    }
}
