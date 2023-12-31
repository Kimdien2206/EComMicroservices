
namespace Dto.ProductDto
{
    public class CollectionDto 
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int? DiscountId { get; set; }

        public virtual DiscountDto? Discount { get; set; }

        public virtual ICollection<ProductDto> Products { get; set; } = new List<ProductDto>();

    }
}
