﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecom.Services.Forecasts.Models
{
    public class Forecast
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [DefaultValue("1970/1/1")]
        [Column("last_updated")]
        public DateOnly LastUpdated { get; set; }

        [Column("product_id")]
        public int ProductId { get; set; }
    }
}
