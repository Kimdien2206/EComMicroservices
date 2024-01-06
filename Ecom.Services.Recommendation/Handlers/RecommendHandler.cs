using Ecom.Services.Recommendation.Models;
using Ecom.Services.Recommendation.Service;
using Messages;
using Messages.RecommendMessages;
using NServiceBus.Logging;

namespace Ecom.Services.Recommendation.Handlers
{
    public class RecommendHandler : IHandleMessages<GetRecommendedProductCommand>
    {
        static ILog log = LogManager.GetLogger<RecommendHandler>();
        public async Task Handle(GetRecommendedProductCommand message, IMessageHandlerContext context)
        {
            var response = new Response<int>();

            try
            {
                var subdirectory = "TrainedModel";
                var modelFileName = "trained_model.zip";

                var currentDirectory = Directory.GetCurrentDirectory();

                // Combine the current directory, subdirectory, and model file name
                var modelFilePath = Path.Combine(currentDirectory, subdirectory, modelFileName);


                if (File.Exists(modelFilePath))
                {
                    List<ProductPredictionScore> recommendedIds = new List<ProductPredictionScore>();
                    var modelLoaded = RecommendationService.MLContext.Model.Load(modelFilePath, out var modelSchema);

                    var predictionEngine = RecommendationService.MLContext.Model.CreatePredictionEngine<UserPurchase, ProductPrediction>(modelLoaded);

                    foreach (var id in message.ProductIds)
                    {
                        if (id == message.ProductId)
                        { continue; }
                        var prediction = predictionEngine.Predict(new UserPurchase { ProductId = message.ProductId, CoPurchaseProducId = id });
                        if (prediction.Score > 0)
                            recommendedIds.Add(new ProductPredictionScore { ProductId = id, Score = prediction.Score });

                        log.Info($"Score of product {id}: {prediction.Score}");
                    }

                    response.responseData = recommendedIds.OrderByDescending(ele => ele.Score).Take(5).Select(ele => ele.ProductId);
                    response.ErrorCode = 200;
                }
                else
                {
                    response.ErrorCode = 503;
                }
            }
            catch (Exception ex)
            {
                log.Error($"Error: {ex.Message}");
                log.Error(ex.StackTrace);
                response.ErrorCode = 500;
            }

            await context.Reply(response);
        }
    }
}
