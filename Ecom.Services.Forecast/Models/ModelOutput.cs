using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecom.Services.Forecast.Models
{
    public class ModelOutput
    {
        public float[] ForecastedSold { get; set; }

        public float[] LowerBoundSold { get; set; }

        public float[] UpperBoundSold { get; set; }
    }
}
