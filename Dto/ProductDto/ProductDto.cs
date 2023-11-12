namespace Dto.ProductDto
{
    public class ProductDto
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public int Price { get; set; }

        public string? Description { get; set; }

        public string[]? Image { get; set; }

        public int View { get; set; }

        public int Sold { get; set; }

        public bool? IsActive { get; set; }

        public int? DiscountId { get; set; }

        public int? CollectionId { get; set; }

        public string Slug { get; set; } = null!;

        public virtual ICollection<HaveTagDto> HaveTags { get; set; } = new List<HaveTagDto>();

        public virtual ICollection<ProductItemDto> ProductItems { get; set; } = new List<ProductItemDto>();
    }
}