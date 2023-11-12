using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECom.Services.Products.Models;

public partial class ProductItem
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("id")]
    public int Id { get; set; }

    [Required]
    [Column("color")]
    public string Color { get; set; } = null!;

    [Required]
    [Column("size")]  
    public string Size { get; set; } = null!;

    [Required]
    [Column("quantity")]
    public int Quantity { get; set; }

    [Column("image")]
    public string[]? Image { get; set; }

    [Required]
    [Column("product_id")]
    [ForeignKey("Product")]
    public int ProductId { get; set; }
}
