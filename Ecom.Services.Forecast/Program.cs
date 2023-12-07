

using Ecom.Services.Forecast.Models;
using Ecom.Services.Forecast.Service;
using Microsoft.ML;
using Microsoft.ML.Transforms.TimeSeries;
using static Microsoft.ML.ForecastingCatalog;

namespace ECom.Services.Forecast
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Forecast System";

            ForecastService service = new ForecastService();

            var trainingData2018Path = Path.Combine(Environment.CurrentDirectory, "Data", "data_2018.csv");
            var trainingData2019Path = Path.Combine(Environment.CurrentDirectory, "Data", "data_2019.csv");
            var trainingData2020Path = Path.Combine(Environment.CurrentDirectory, "Data", "data_2020.csv");
            var trainingData2021Path = Path.Combine(Environment.CurrentDirectory, "Data", "data_2021.csv");
            var testData2022Path = Path.Combine(Environment.CurrentDirectory, "Data", "data_2022.csv");

            var traningDataPaths = new List<string>();
            traningDataPaths.Add(trainingData2018Path);
            traningDataPaths.Add(trainingData2019Path);
            traningDataPaths.Add(trainingData2020Path);
            traningDataPaths.Add(trainingData2021Path);

            var testDataPaths = new List<string>();
            testDataPaths.Add(testData2022Path);

            IDataView trainingData = service.LoadData(traningDataPaths);
            IDataView testData = service.LoadData(testDataPaths);



            ITransformer model = service.BuildAndTrainModel(trainingData);
            service.EvaluateModel(testData, model);

            var forecastEngine = model.CreateTimeSeriesEngine<ModelInput, ModelOutput>(service.MLContext);

            //forecastEngine.CheckPoint(service.MLContext, modelPath);

            service.Forecast(testData, 7, forecastEngine, service.MLContext);
        }
    }
}