using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ML.Data;

namespace Ecom.Services.Forecast.Models
{
    public class ModelInput
    {
        [LoadColumn(1)]
        public float TotalSold { get; set; }
        [LoadColumn(2)]
        public DateTime SoldDate { get; set; }
        [LoadColumn(3)]
        public float Year { get; set; }
        
    }
}
