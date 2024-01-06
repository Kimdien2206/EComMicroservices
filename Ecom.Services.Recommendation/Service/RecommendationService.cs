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
            List<UserPurchase> modelInputs = new List<UserPurchase>();

            foreach (OrderDto orderDto in orderDtos)
            {
                if (orderDto.OrderDetails.Count > 1)
                {
                    var orderDetails = orderDto.OrderDetails.ToList();
                    for (int i = 1; i < orderDto.OrderDetails.Count; i++)
                    {
                        var detailDto = orderDetails[0];
                        var coPurchaseDetail = orderDetails[i];
                        if (detailDto.ProductItem != null)
                            modelInputs.Add(new UserPurchase() { ProductId = (float)detailDto.ProductItem.ProductId, CoPurchaseProducId = (float)coPurchaseDetail.ProductItem.ProductId, Label = 0 });
                    }
                }
            }

            dataView = MLContext.Data.LoadFromEnumerable(modelInputs);
            return dataView;
        }

        static public ITransformer BuildAndTrainModel(IDataView trainData)
        {
            IEstimator<ITransformer> estimator = MLContext.Transforms.Conversion
                .MapValueToKey(outputColumnName: "productIdEncoded", inputColumnName: nameof(UserPurchase.ProductId))
    .Append(MLContext.Transforms.Conversion.MapValueToKey(outputColumnName: "coPurchaseProductIdEncoded", inputColumnName: nameof(UserPurchase.CoPurchaseProducId)));

            MatrixFactorizationTrainer.Options options = new MatrixFactorizationTrainer.Options();
            options.MatrixColumnIndexColumnName = "productIdEncoded";
            options.MatrixRowIndexColumnName = "coPurchaseProductIdEncoded";
            options.LabelColumnName = "Label";
            options.LossFunction = MatrixFactorizationTrainer.LossFunctionType.SquareLossOneClass;
            options.Alpha = 0.01;
            options.Lambda = 0.025;

            var trainerEstimator = estimator.Append(MLContext.Recommendation().Trainers.MatrixFactorization(options));
            //Step 4: Call the MatrixFactorization trainer by passing options.
            var est = MLContext.Recommendation().Trainers.MatrixFactorization(options);

            //STEP 5: Train the model fitting to the DataSet
            Console.WriteLine("=============== Training the model ===============");
            ITransformer model = trainerEstimator.Fit(trainData);

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

        static public void LoadModel() { }
    }
}
