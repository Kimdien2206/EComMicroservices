using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECom.Services.Billing.Models;

public partial class Receipt
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("id")]
    public int Id { get; set; }

    [Required]
    [Column("date")]
    public DateTime Date { get; set; }

    [Required]
    [Column("cost")]
    public int Cost { get; set; }

    [Column("status")]
    [DefaultValue('0')]
    public char Status { get; set; } = '0';

    [Column("voucher_code")]
    public string? VoucherCode { get; set; }

    [Column("order_id")]
    [Required]
    public int OrderId { get; set; }

    [Column("payment_method")]
    [Required]
    public string PaymentMethod { get; set; } = null!;

}
