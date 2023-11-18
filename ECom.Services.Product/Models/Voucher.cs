using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_commerce_shop_2.Models;

public partial class Voucher
{
    [Key]
    [Column("code")]
    public string Code { get; set; } = null!;

    [Required]
    [Column("name")]
    public string Name { get; set; } = null!;

    [Required]
    [Column("discount")]
    public double Discount { get; set; }

    [Column("description")]
    public string? Description { get; set; }

    [Required]
    [Column("due")]
    public DateOnly Due { get; set; }

    [Column("is_active")]
    [DefaultValue(true)]
    public bool? IsActive { get; set; }
}
