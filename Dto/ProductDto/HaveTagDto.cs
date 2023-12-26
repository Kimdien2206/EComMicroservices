
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Dto.ProductDto
{
    public class HaveTagDto 
    {
        public int Id { get; set; }

        public int TagId { get; set; }

        public int ProductId { get; set; }
    }
}
