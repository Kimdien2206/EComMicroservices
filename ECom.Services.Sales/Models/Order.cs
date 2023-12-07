using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;

namespace ECom.Services.Sales.Models;

public partial class Order
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("id")]
    public int Id { get; set; }

    [Required]
    [Column("date")]
    public DateTime Date { get; set; } 

    [Required]
    [Column("total_cost")]
    public int TotalCost { get; set; }

    [Required]
    [DefaultValue("0")]
    [Column("status")]
    public char Status { get; set; }

    [Column("address")]
    [Required]
    public string Address { get; set; } = null!;

    [Column("firstname")]
    [Required]
    public string Firstname { get; set; } = null!;

    [Column("lastname")]
    [Required]
    public string? Lastname { get; set; }

    [Column("phone_number")]
    [Required]
    public string PhoneNumber { get; set; } = null!;

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
}
