using Messages.ProductMessages;
using Messages.ReportMessages;
using Microsoft.Extensions.Hosting;

namespace ECom.Services.Forecasts
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.Title = "Forecast System";

            await Host.CreateDefaultBuilder(args)
                .UseNServiceBus(context =>
                {
                    var endpointConfiguration = new EndpointConfiguration("Forecast");

                    var transport = endpointConfiguration.UseTransport<LearningTransport>();
                    endpointConfiguration.UseSerialization<SystemJsonSerializer>();
                    endpointConfiguration.UsePersistence<LearningPersistence>();

                    var route = transport.Routing();

                    route.RouteToEndpoint(typeof(GetAllProductIdsCommand), "Product");
                    route.RouteToEndpoint(typeof(GetAllDailyDetailReport), "Reports");

                    return endpointConfiguration;
                })
                .RunConsoleAsync();

            //ForecastService service = new ForecastService();

            //var trainingData2021Path = Path.Combine(Environment.CurrentDirectory, "StaticData", "day.csv");
            //var testData2022Path = Path.Combine(Environment.CurrentDirectory, "StaticData", "day.csv");

            //var traningDataPaths = new List<string>();
            //traningDataPaths.Add(trainingData2021Path);

            //var testDataPaths = new List<string>();
            //testDataPaths.Add(testData2022Path);

            //IDataView trainingData = service.LoadDataFromCsv(traningDataPaths, 0);
            //IDataView testData = service.LoadDataFromCsv(testDataPaths, 1);

            //ITransformer model = service.BuildAndTrainModel(trainingData);
            //service.EvaluateModel(testData, model);

            //var forecastEngine = model.CreateTimeSeriesEngine<ModelInput, ModelOutput>(service.MLContext);

            //Console.WriteLine("Finished!");
        }
    }
}