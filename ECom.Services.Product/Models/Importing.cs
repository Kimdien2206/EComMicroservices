using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECom.Services.Products.Models;

public partial class Importing
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
    [Column("total_amount")]
    public int TotalAmount { get; set; }

    public virtual ICollection<ImportDetail> ImportDetails { get; set; } = new List<ImportDetail>();
}
