using System.Globalization;
using CsvHelper;
using Dto.OrderDto;
using Ecom.Services.Recommendation.Models;
using Microsoft.ML;
using Microsoft.ML.Trainers;

namespace Ecom.Services.Recommendation.Service
{
    public static class RecommendationService
    {
        static public MLContext MLContext = new MLContext();

        static public IDataView ConvertData(List<OrderDto> orderDtos)
        {
            IDataView dataView;
            List<ProductRating> modelInputs = new List<ProductRating>();

            foreach (OrderDto orderDto in orderDtos)
            {
                if (orderDto.User != null)
                {
                    foreach (OrderDetailDto detailDto in orderDto.OrderDetails)
                    {
                        var currentDate = DateTime.Now;
                        var birthdate = orderDto.User.DateOfBirth;
                        // Calculate age
                        int age = currentDate.Year - birthdate.Year;

                        // Check if the birthday has occurred this year
                        if (birthdate.Date > currentDate.AddYears(-age))
                        {
                            age--;
                        }

                        modelInputs.Add(new ProductRating() { productId = detailDto.Product.Id, userId = orderDto.PhoneNumber, age = age, Label = 1 });
                    }
                }
            }

            dataView = MLContext.Data.LoadFromEnumerable<ProductRating>(modelInputs);
            return dataView;
        }

        static public (IDataView training, IDataView test) LoadData(string source, double traningSetRatio)
        {
            (List<ProductRating> trainData, List<ProductRating> testData) = loadData(source, traningSetRatio);

            IDataView trainingDataView = MLContext.Data.LoadFromEnumerable<ProductRating>(trainData);
            IDataView testDataView = MLContext.Data.LoadFromEnumerable<ProductRating>(testData);

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

        static public ITransformer BuildAndTrainModel(IDataView trainingDataView)
        {
            IEstimator<ITransformer> estimator = MLContext.Transforms.Conversion
                .MapValueToKey(outputColumnName: "ageEncoded", inputColumnName: "age")
    .Append(MLContext.Transforms.Conversion.MapValueToKey(outputColumnName: "productIdEncoded", inputColumnName: "productId"))
    .Append(MLContext.Transforms.Conversion.MapValueToKey(outputColumnName: "userIdEncoded", inputColumnName: "userId"));

            var options = new MatrixFactorizationTrainer.Options
            {
                MatrixColumnIndexColumnName = "userIdEncoded",
                MatrixRowIndexColumnName = "productIdEncoded",
                LabelColumnName = "Label",
                NumberOfIterations = 100,
                ApproximationRank = 100
            };

            var trainerEstimator = estimator.Append(MLContext.Recommendation().Trainers.MatrixFactorization(options));

            Console.WriteLine("=============== Training the model ===============");
            ITransformer model = trainerEstimator.Fit(trainingDataView);

            return model;

        }

        static public void EvaluateModel(IDataView testDataView, ITransformer model)
        {
            Console.WriteLine("=============== Evaluating the model ===============");
            var prediction = model.Transform(testDataView);

            var metrics = MLContext.Regression.Evaluate(prediction, labelColumnName: "Label", scoreColumnName: "Score");

            Console.WriteLine("Root Mean Squared Error : " + metrics.RootMeanSquaredError.ToString());
            Console.WriteLine("RSquared: " + metrics.RSquared.ToString());
        }
    }
}
