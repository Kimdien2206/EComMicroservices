using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECom.Services.Products.Models;

public partial class Review
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("id")]
    public int Id { get; set; }

    [Column("comment")]
    public string? Comment { get; set; }

    [Column("rate")]
    [Required]
    public double Rate { get; set; }

    [Column("product_id")]
    [Required]
    [ForeignKey("Product")]
    public int ProductId { get; set; }

    [Column("customer_id")]
    [Required]
    public int CustomerId { get; set; }

}
