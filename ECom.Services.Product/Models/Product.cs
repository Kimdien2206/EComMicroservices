using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECom.Services.Products.Models;

public partial class Product
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("id")]
    public int Id { get; set; }

    [Required]
    [Column("name")]
    public string Name { get; set; } = null!;

    [Required]
    [Column("price")]
    public int Price { get; set; }

    [Column("description")]
    public string? Description { get; set; }

    [Column("image")]
    [Required]
    public string[]? Image { get; set; }

    [Column("view")]
    [DefaultValue(0)]
    public int View { get; set; }

    [Column("sold")]
    [DefaultValue(0)]
    public int Sold { get; set; }

    [Column("is_active")]
    [DefaultValue(true)]
    public bool? IsActive { get; set; }

    [Column("discount_id")]
    public int? DiscountId { get; set; }

    [Column("collection_id")]
    public int? CollectionId { get; set; }

    [Column("slug")]
    public string Slug { get; set; } = null!;

    public virtual Collection? Collection { get; set; }

    public virtual Discount? Discount { get; set; }

    public virtual ICollection<HaveTag> HaveTags { get; set; } = new List<HaveTag>();

    public virtual ICollection<ProductItem> ProductItems { get; set; } = new List<ProductItem>();

    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();

}
