using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dto.ReceiptDto
{
    public class ReceiptDto
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public int Cost { get; set; }

        public char Status { get; set; }

        public string? VoucherCode { get; set; }

        public int OrderId { get; set; }

        public string PaymentMethod { get; set; } = null!;
    }
}
