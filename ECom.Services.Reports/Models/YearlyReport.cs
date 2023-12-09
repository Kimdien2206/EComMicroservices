using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECom.Services.Reports.Models;

public partial class YearlyReport
{
    [Key]
    [Column("year")]
    public DateOnly Year { get; set; }

    [Column("income")]
    [Required]
    [DefaultValue(0)]
    public int Income { get; set; }

    [Column("outcome")]
    [Required]
    [DefaultValue(0)]
    public int Outcome { get; set; }

    [Column("profit")]
    [Required]
    [DefaultValue(0)]
    public int Profit { get; set; }

    [Column("sold_quantity")]
    [DefaultValue(0)]
    public int SoldQuantity { get; set; }

    public virtual ICollection<MonthlyReport> MonthlyReports { get; set; } = new List<MonthlyReport>();
}
