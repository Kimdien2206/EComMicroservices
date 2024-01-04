using Messages.OrderMessages;
using Messages.UserMessages;
using Microsoft.Extensions.Hosting;

namespace ECom.Services.Recommendation
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.Title = "Recommendation System";

            await Host.CreateDefaultBuilder(args)
                .UseNServiceBus(context =>
                {
                    var endpointConfiguration = new EndpointConfiguration("Recommendation");

                    var transport = endpointConfiguration.UseTransport<LearningTransport>();
                    endpointConfiguration.UseSerialization<SystemJsonSerializer>();
                    endpointConfiguration.UsePersistence<LearningPersistence>();

                    var route = transport.Routing();

                    route.RouteToEndpoint(typeof(GetAllOrdersCommand), "Sales");
                    route.RouteToEndpoint(typeof(GetAllUsersCommand), "Auth");

                    return endpointConfiguration;
                })
                .RunConsoleAsync();

            //RecommendationService service = new RecommendationService();

            //var trainingDataPath = Path.Combine(Environment.CurrentDirectory, "Data", "Womens_Clothing_E_Commerce_Reviews.csv");

            //(IDataView training, IDataView test) = service.LoadData(trainingDataPath, 0.8);

            //ITransformer model = service.BuildAndTrainModel(training);

            //service.EvaluateModel(test, model);


            //Console.WriteLine("=============== Making a prediction ===============");
            //var predictionEngine = service.MLContext.Model.CreatePredictionEngine<ProductRating, ProductPrediction>(model);



            //List<int> dataList = new List<int>
            //{
            //    767, 1080, 1077, 1049, 847, 858, 1095, 1065, 853, 1120,
            //    697, 949, 1003, 684, 4, 1060, 1002, 862, 910, 89, 823,
            //    1104, 368, 1078, 845, 822
            //};

            //int age = 20;

            //foreach (var productId in dataList)
            //{
            //    Console.WriteLine("==============================");
            //    ProductRating productRating = new ProductRating()
            //    {
            //        age = age,
            //        productId = productId
            //    };
            //    var predictScore = predictionEngine.Predict(productRating);

            //    Console.WriteLine("Score: " + predictScore.Score);

            //    if (Math.Round(predictScore.Score, 1) > 4)
            //    {
            //        Console.WriteLine("Product " + productRating.productId + " is recommended for user " + productRating.age);
            //    }
            //    else
            //    {
            //        Console.WriteLine("Product " + productRating.productId + " is not recommended for user " + productRating.age);
            //    }
            //    Console.WriteLine("==============================");
        }


    }
}
