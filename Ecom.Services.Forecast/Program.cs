

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

            var trainingDataPath = Path.Combine(Environment.CurrentDirectory, "Data", "data_2022.csv");
            var testDataPath = Path.Combine(Environment.CurrentDirectory, "Data", "data_2021.csv");

            IDataView training = service.LoadData(trainingDataPath);
            Console.WriteLine(training.GetRowCount());

            IDataView test = service.LoadData(testDataPath);
            Console.WriteLine(test.GetRowCount());

            ITransformer model = service.BuildAndTrainModel(training);
            service.EvaluateModel(test, model);

            var forecastEngine = model.CreateTimeSeriesEngine<ModelInput, ModelOutput>(service.MLContext);

            //forecastEngine.CheckPoint(service.MLContext, modelPath);

            service.Forecast(test, 7, forecastEngine, service.MLContext);
        }
    }
}