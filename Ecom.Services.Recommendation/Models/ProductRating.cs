using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ML.Data;

namespace Ecom.Services.Recommendation.Models
{
    internal class ProductRating
    {
        [LoadColumn(0)]
        public float productId;
        [LoadColumn(1)]
        public float age;
        [LoadColumn(2)]
        public float Label;
    }
}
