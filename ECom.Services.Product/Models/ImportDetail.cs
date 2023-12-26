using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECom.Services.Products.Models;

public partial class ImportDetail
{

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("id")]
    public int Id { get; set; }

    [Required]
    [Column("item")]
    [ForeignKey("ProductItem")]
    public int Item { get; set; }

    [Required]
    [Column("quantity")]
    public int Quantity { get; set; }

    [Required]
    [Column("price")]
    public int Price { get; set; }

    [Required]
    [Column("import_id")]
    [ForeignKey("Importing")]
    public int ImportId { get; set; }

    [Required]
    [Column("total_cost")]
    public int TotalCost { get; set; }

    public virtual Importing Importing { get; set; } = null!;

    public virtual ProductItem ProductItem { get; set; } = null!;
}
