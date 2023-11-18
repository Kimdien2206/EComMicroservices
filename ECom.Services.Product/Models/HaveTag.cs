using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace ECom.Services.Products.Models;

public partial class HaveTag
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("id")]
    public int Id { get; set; }

    [Column("tag_id")]
    [Required]
    public int TagId { get; set; }

    [Required]
    [Column("product_id")]
    public int ProductId { get; set; }


    public virtual Product Product { get; set; } = null!;

    public virtual Tag Tag { get; set; } = null!;

}
