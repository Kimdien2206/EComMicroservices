
using Ecom.Services.Recommendation.Service;
using Microsoft.ML;
using Microsoft.ML.Runtime;

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
        }
    }
}