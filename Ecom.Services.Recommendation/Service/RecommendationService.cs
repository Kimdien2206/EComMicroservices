using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;
using Ecom.Services.Recommendation.Models;
using Microsoft.ML;
using Microsoft.ML.Trainers;

namespace Ecom.Services.Recommendation.Service
{
    public class RecommendationService
    {
        MLContext mlContext;
        public RecommendationService() {
            mlContext = new MLContext();
        }

        public (IDataView training, IDataView test) LoadData(string source, double traningSetRatio)
        {
            (List<ProductRating> trainData, List<ProductRating> testData) = loadData(source, traningSetRatio);

            IDataView trainingDataView = mlContext.Data.LoadFromEnumerable<ProductRating>(trainData);
            IDataView testDataView = mlContext.Data.LoadFromEnumerable<ProductRating>(testData);

            return (trainingDataView, testDataView);
        }

        private static (List<ProductRating>, List<ProductRating>) loadData(string source, double trainingSetRatio)
        {
            List<ProductRating> trainSamples = new List<ProductRating>();
            List<ProductRating> testSamples = new List<ProductRating>();
            // Open CSV file for reading
            using (var fileReader = new StreamReader(source))
            {
                using (var csv = new CsvReader(fileReader, CultureInfo.InvariantCulture))
                {
                    var records = new List<ProductRating>();
                    var rows = csv
                        .GetRecords<ProductSample>()
                        .ToList();
                    for (var i = 0; i < rows.Count(); i++)
                    {
                        var record = new ProductRating
                        {
                            productId = rows[i].Id,
                            age = rows[i].Age,
                            Label = rows[i].Rating
                        };
                        Console.WriteLine(record);
                        if (i < rows.Count() * trainingSetRatio)
                        {
                            trainSamples.Add(record);
                        }
                        else
                        {
                            testSamples.Add(record);
                        }
                    }
                        
                }
            }
            return (trainSamples, testSamples);
        }

        public ITransformer BuildAndTrainModel(IDataView trainingDataView)
        {
            Console.WriteLine(trainingDataView);
            IEstimator<ITransformer> estimator = mlContext.Transforms.Conversion.MapValueToKey(outputColumnName: "ageEncoded", inputColumnName: "age")
    .Append(mlContext.Transforms.Conversion.MapValueToKey(outputColumnName: "productIdEncoded", inputColumnName: "productId"));

            var options = new MatrixFactorizationTrainer.Options
            {
                MatrixColumnIndexColumnName = "ageEncoded",
                MatrixRowIndexColumnName = "productIdEncoded",
                LabelColumnName = "Label",
                NumberOfIterations = 20,
                ApproximationRank = 100
            };

            var trainerEstimator = estimator.Append(mlContext.Recommendation().Trainers.MatrixFactorization(options));

            Console.WriteLine("=============== Training the model ===============");
            ITransformer model = trainerEstimator.Fit(trainingDataView);

            return model;

        }

        public void EvaluateModel(IDataView testDataView, ITransformer model)
        {
            Console.WriteLine("=============== Evaluating the model ===============");
            var prediction = model.Transform(testDataView);

            var metrics = mlContext.Regression.Evaluate(prediction, labelColumnName: "Label", scoreColumnName: "Score");

            Console.WriteLine("Root Mean Squared Error : " + metrics.RootMeanSquaredError.ToString());
            Console.WriteLine("RSquared: " + metrics.RSquared.ToString());
        }
    }
}
