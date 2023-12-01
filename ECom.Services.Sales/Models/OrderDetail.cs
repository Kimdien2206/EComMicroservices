using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECom.Services.Sales.Models;

public partial class OrderDetail
{

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("id")]
    public int Id { get; set; }

    [Required]
    [Column("order_id")]
    [ForeignKey("Order")]
    public int OrderId { get; set; }

    [Required]
    [Column("quantity")]
    public int Quantity { get; set; }

    [Required]
    [Column("item_id")]
    public int ItemId { get; set; }

    public virtual Order Order { get; set; } = null!;
}
