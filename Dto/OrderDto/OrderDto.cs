using Dto.AuthDto;

namespace Dto.OrderDto
{
    public class OrderDto
    {
        public int? Id { get; set; }

        public DateTime Date { get; set; }

        public int TotalCost { get; set; }

        public char Status { get; set; }

        public string Address { get; set; } = null!;

        public string Firstname { get; set; } = null!;

        public string? Lastname { get; set; }

        public string PhoneNumber { get; set; } = null!;

        public UserDto? User { get; set; }

        public virtual ICollection<OrderDetailDto> OrderDetails { get; set; } = new List<OrderDetailDto>();
    }
}
