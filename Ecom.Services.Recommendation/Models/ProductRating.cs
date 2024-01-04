using Microsoft.ML.Data;

namespace Ecom.Services.Recommendation.Models
{
    internal class ProductRating
    {
        public string userId;
        [LoadColumn(0)]
        public float productId;
        [LoadColumn(1)]
        public float age;
        [LoadColumn(2)]
        public float Label;
    }
}
