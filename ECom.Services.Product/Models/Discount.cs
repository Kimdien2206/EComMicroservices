using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECom.Services.Products.Models;

public partial class Discount
{
    [Key]
    [Column("id")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Column("discount_amount")]
    [Required]
    public double DiscountAmount { get; set; }

    [Required]
    [Column("name")]
    public string Name { get; set; } = null!;

    public virtual ICollection<Collection> Collections { get; set; } = new List<Collection>();

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();

    public virtual ICollection<Tag> Tags { get; set; } = new List<Tag>();

}
