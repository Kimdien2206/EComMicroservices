
using Ecom.Services.Recommendation.Models;
using Ecom.Services.Recommendation.Service;
using Microsoft.ML;

namespace ECom.Services.Recommendation
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.Title = "Recommendation System";
            
            RecommendationService service = new RecommendationService();

            var trainingDataPath = Path.Combine(Environment.CurrentDirectory, "Data", "Womens_Clothing_E_Commerce_Reviews.csv");

            (IDataView training, IDataView test) =  service.LoadData(trainingDataPath, 0.8);

            ITransformer model = service.BuildAndTrainModel(training);

            service.EvaluateModel(test, model);

            ProductRating productRatingTest = new ProductRating() { age = 20, productId = 1033 };

            Console.WriteLine("=============== Making a prediction ===============");
            var predictionEngine = service.MLContext.Model.CreatePredictionEngine<ProductRating, ProductPrediction>(model);

            var predictScore = predictionEngine.Predict(productRatingTest);

            Console.WriteLine("Score: " +  predictScore.Score);

            if (Math.Round(predictScore.Score, 1) > 3.5)
            {
                Console.WriteLine("Movie " + productRatingTest.productId + " is recommended for user " + productRatingTest.age);
            }
            else
            {
                Console.WriteLine("Movie " + productRatingTest.productId + " is not recommended for user " + productRatingTest.age);
            }
        }
    }
}