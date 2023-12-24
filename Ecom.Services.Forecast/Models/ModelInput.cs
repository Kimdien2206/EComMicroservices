using Microsoft.ML.Data;

namespace Ecom.Services.Forecasts.Models
{
    public class ModelInput
    {

        [LoadColumn(0)]
        public DateTime SoldDate { get; set; }
        [LoadColumn(1)]
        public float Year { get; set; }
        [LoadColumn(2)]
        public float TotalSold { get; set; }

    }
}
