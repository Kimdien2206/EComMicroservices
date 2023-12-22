using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecom.Services.Forecasts.Models
{
    public class ForecastDetail
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [DefaultValue("1970/1/1")]
        [Column("date")]
        public DateOnly date { get; set; }

        [DefaultValue(0)]
        [Column("total_sold")]
        public int TotalSold { get; set; }

        [Column("forecast_id")]
        public int ForecastId { get; set; }

        [ForeignKey(nameof(ForecastId))]
        public virtual Forecast Forecast { get; set; }
    }
}
