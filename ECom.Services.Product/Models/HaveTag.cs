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
    [ForeignKey("Tag")]
    public int TagId { get; set; }

    [Required]
    [Column("product_id")]
    [ForeignKey("Product")]
    public int ProductId { get; set; }

}
