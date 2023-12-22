

using Ecom.Services.Forecasts.Models;
using Ecom.Services.Forecasts.Service;
using Microsoft.ML;
using Microsoft.ML.Transforms.TimeSeries;

namespace ECom.Services.Forecasts
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.Title = "Forecast System";

            ForecastService service = new ForecastService();

            var trainingData2021Path = Path.Combine(Environment.CurrentDirectory, "StaticData", "day.csv");
            var testData2022Path = Path.Combine(Environment.CurrentDirectory, "StaticData", "day.csv");

            var traningDataPaths = new List<string>();
            traningDataPaths.Add(trainingData2021Path);

            var testDataPaths = new List<string>();
            testDataPaths.Add(testData2022Path);

            IDataView trainingData = service.LoadDataFromCsv(traningDataPaths, 0);
            IDataView testData = service.LoadDataFromCsv(testDataPaths, 1);


            ITransformer model = service.BuildAndTrainModel(trainingData);
            service.EvaluateModel(testData, model);

            var forecastEngine = model.CreateTimeSeriesEngine<ModelInput, ModelOutput>(service.MLContext);

            var modelPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ForecastModel.zip");
            if (!File.Exists(modelPath))
                forecastEngine.CheckPoint(service.MLContext, modelPath);

            //string projectName = "YourProjectName"; // Replace with your actual project name
            //string relativePath = "TrainedModel";
            //string fileName = "yourfile.txt";

            //string projectDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", projectName);
            //string fullPath = Path.Combine(projectDirectory, relativePath, fileName);

            //// Check if the directory exists, if not, create it
            //if (!Directory.Exists(Path.Combine(projectDirectory, relativePath)))
            //{
            //    Directory.CreateDirectory(Path.Combine(projectDirectory, relativePath));
            //}

            Console.WriteLine("Finished!");


        }
    }
}