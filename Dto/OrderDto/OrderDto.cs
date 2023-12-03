using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dto.OrderDto
{
    public class OrderDto
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public int TotalCost { get; set; }

        public char Status { get; set; }

        public string Address { get; set; } = null!;

        public string Firstname { get; set; } = null!;

        public string? Lastname { get; set; }

        public string PhoneNumber { get; set; } = null!;
    }
}
