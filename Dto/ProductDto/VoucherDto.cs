namespace Dto.ProductDto
{
    public class VoucherDto
    {
        public string Code { get; set; } = null!;

        public string Name { get; set; } = null!;

        public double Discount { get; set; }

        public string? Description { get; set; }

        public DateOnly Due { get; set; }

        public bool? IsActive { get; set; }
    }
}
