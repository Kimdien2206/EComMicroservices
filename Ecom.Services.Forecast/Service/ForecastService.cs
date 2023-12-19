using System;
using System.Collections.Generic;
using System.Data;
using System.Formats.Asn1;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;
using Ecom.Services.Forecast.Models;
using Microsoft.ML;
using Microsoft.ML.Transforms.TimeSeries;

namespace Ecom.Services.Forecast.Service
{
    public class ForecastService
    {
        MLContext mlContext;

        public MLContext MLContext { get { return mlContext; } }
        public ForecastService()
        {
            mlContext = new MLContext();
        }

        public IDataView LoadData(List<string> sources, int year)
        {
            IDataView trainingDataView;
            List<ModelInput> trainingInputs = new List<ModelInput>();

            for (int i = 0; i < sources.Count; i++)
            {
                using (var fileReader = new StreamReader(sources[i]))
                {
                    using (var csv = new CsvReader(fileReader, CultureInfo.InvariantCulture))
                    {
                        var records = new List<ModelInput>();
                        var rows = csv
                            .GetRecords<ModelInput>()
                            .Where(input => input.Year == year).ToList();

                        trainingInputs.AddRange(rows);
                    }
                }
            }

            trainingDataView  = mlContext.Data.LoadFromEnumerable<ModelInput>(trainingInputs);
            return trainingDataView;
        }

        public ITransformer BuildAndTrainModel(IDataView trainingDataView)
        {
            var forecastingPipeline = mlContext.Forecasting.ForecastBySsa(
                outputColumnName: "ForecastedSold",
                inputColumnName: "TotalSold",
                windowSize: 7,
                seriesLength: 30,
                trainSize: 30,
                horizon: 30,
                confidenceLevel: 0.90f,
                confidenceLowerBoundColumn: "LowerBoundSold",
                confidenceUpperBoundColumn: "UpperBoundSold");


            SsaForecastingTransformer forecaster = forecastingPipeline.Fit(trainingDataView);

            return forecaster;
        }

        public void EvaluateModel(IDataView testDataView, ITransformer model)
        {
            Console.WriteLine("=============== Evaluating the model ===============");
            IDataView predictions = model.Transform(testDataView);

            IEnumerable<float> actual =
    mlContext.Data.CreateEnumerable<ModelInput>(testDataView, true)
        .Select(observed => observed.TotalSold);

            IEnumerable<float> forecast =
    mlContext.Data.CreateEnumerable<ModelOutput>(predictions, true)
        .Select(prediction => 
             prediction.ForecastedSold[0]
            );

            var metrics = actual.Zip(forecast, (actualValue, forecastValue) => actualValue - forecastValue);

            var MAE = metrics.Average(error => Math.Abs(error)); // Mean Absolute Error
            var RMSE = Math.Sqrt(metrics.Average(error => Math.Pow(error, 2))); // Root Mean Squared Error

            Console.WriteLine("Evaluation Metrics");
            Console.WriteLine("---------------------");
            Console.WriteLine($"Mean Absolute Error: {MAE:F3}");
            Console.WriteLine($"Root Mean Squared Error: {RMSE:F3}\n");
        }

        public void Forecast(IDataView testData, int horizon, TimeSeriesPredictionEngine<ModelInput, ModelOutput> forecaster, MLContext mlContext)
        {
            ModelOutput forecast = forecaster.Predict();

            IEnumerable<string> forecastOutput =
    mlContext.Data.CreateEnumerable<ModelInput>(testData, reuseRowObject: false)
        .Take(horizon)
        .Select((ModelInput rental, int index) =>
        {
            string rentalDate = rental.SoldDate.ToShortDateString();
            float actualRentals = rental.TotalSold;
            float lowerEstimate = Math.Max(0, forecast.LowerBoundSold[index]);
            float estimate = forecast.ForecastedSold[index];
            float upperEstimate = forecast.UpperBoundSold[index];
            return $"Date: {rentalDate}\n" +
            $"Actual Sold: {actualRentals}\n" +
            $"Lower Estimate: {lowerEstimate}\n" +
            $"Forecast: {estimate}\n" +
            $"Upper Estimate: {upperEstimate}\n";
        });
            Console.WriteLine("Rental Forecast");
            Console.WriteLine("---------------------");
            foreach (var prediction in forecastOutput)
            {
                Console.WriteLine(prediction);
            }
        }
    }
}
