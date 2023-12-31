
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Dto.ProductDto
{
    public class TagDto
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public int? DiscountId { get; set; }

        public virtual DiscountDto? Discount { get; set; }
    }
}
