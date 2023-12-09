using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECom.Services.Reports.Models;

public partial class DailyReport
{
    [Key]
    [Column("date")]
    public DateOnly Date { get; set; }

    [DefaultValue(0)]
    [Column("income")]
    public long Income { get; set; }

    [DefaultValue(0)]
    [Column("outcome")]
    public long Outcome { get; set; }

    [DefaultValue(0)]
    [Column("profit")]
    public long Profit { get; set; }

    [DefaultValue(0)]
    [Column("sold_quantity")]
    public int SoldQuantity { get; set; }

    [Column("month")]
    public DateOnly Month { get; set; }

    public virtual ICollection<DailyReportDetail> Details { get; set; } = null!;
}
