using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECom.Services.Reports.Models;

public partial class MonthlyReport
{
    [Key]
    [Column("month")]
    public DateOnly Month { get; set; }

    [Column("income")]
    [DefaultValue(0)]
    public long Income { get; set; }

    [Column("outcome")]
    [DefaultValue(0)]
    public long Outcome { get; set; }

    [Column("profit")]
    [DefaultValue(0)]
    public long Profit { get; set; }

    [Column("sold_quantity")]
    [DefaultValue(0)]
    public int SoldQuantity { get; set; }

    [Column("year")]
    public DateOnly Year { get; set; }

    public virtual ICollection<DailyReport> DailyReports { get; set; } = new List<DailyReport>();
}
