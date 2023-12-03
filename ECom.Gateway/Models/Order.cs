using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ECom.Gateway.Models
{
    public class Order
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public int TotalCost { get; set; }

        public char Status { get; set; }

        public string Address { get; set; } = null!;

        public string Firstname { get; set; } = null!;

        public string? Lastname { get; set; }

        public string PhoneNumber { get; set; } = null!;

        public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
    }
}
