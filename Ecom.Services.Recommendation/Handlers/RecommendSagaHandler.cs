using Ecom.Services.Recommendation.Models;
using Ecom.Services.Recommendation.Service;
using Messages;
using Messages.OrderMessages;
using Messages.ProductMessages;
using Messages.RecommendMessages;
using Messages.UserMessages;
using Microsoft.ML;
using NServiceBus.Logging;
using SagaData.Recommendation;

namespace Ecom.Services.Recommendation.Handlers
{
    public class RecommendSagaHandler : Saga<RecommendSagaData>, IAmStartedByMessages<TrainRecommenderModelCommand>, IHandleMessages<GetAllOrdersResponse>, IHandleMessages<GetAllUsersResponse>, IHandleMessages<GetAllProductItemsResponse>
    {
        ILog log = LogManager.GetLogger<RecommendSagaHandler>();

        public async Task Handle(TrainRecommenderModelCommand message, IMessageHandlerContext context)
        {
            var response = new Response<string>() { ErrorCode = 202 };
            try
            {

                await context.Send(new GetAllOrdersCommand() { SagaId = message.SagaId });

                await context.Send(new GetAllUsersCommand() { SagaId = message.SagaId });

                await context.Send(new GetAllProductItemsCommand() { SagaId = message.SagaId });
            }
            catch (Exception ex)
            {
                log.Error($"Error: {ex.Message}");
                log.Error(ex.StackTrace);
                response.ErrorCode = 500;
            }
            await context.Reply(response);
        }

        public async Task Handle(GetAllOrdersResponse message, IMessageHandlerContext context)
        {
            log.Info($"Forecast saga {message.SagaId} received {message.Orders.Count} orders");
            this.Data.Orders = message.Orders;

            await processTraining(context);
        }

        public async Task Handle(GetAllUsersResponse message, IMessageHandlerContext context)
        {
            log.Info($"Forecast saga {message.SagaId} received {message.Users.Count} users");
            this.Data.Users = message.Users;

            await processTraining(context);
        }

        public async Task Handle(GetAllProductItemsResponse message, IMessageHandlerContext context)
        {
            log.Info($"Forecast saga {message.SagaId} received {message.ProductItems.Count} product item");
            this.Data.ProductItems = message.ProductItems;

            await processTraining(context);
        }

        private async Task processTraining(IMessageHandlerContext context)
        {
            if (this.Data.Orders != null && this.Data.Users != null && this.Data.ProductItems != null)
                if (this.Data.Orders.Count > 0 && this.Data.Users.Count > 0 && this.Data.ProductItems.Count > 0)
                {
                    List<string> userIds = this.Data.Users.Select(user => user.PhoneNumber).ToList();

                    foreach (var order in this.Data.Orders)
                    {
                        foreach (var item in order.OrderDetails)
                        {
                            item.ProductItem = this.Data.ProductItems.FirstOrDefault(ele => ele.Id == item.ItemId);
                        }
                    }

                    var trainData = RecommendationService.ConvertData(this.Data.Orders);

                    ITransformer model = RecommendationService.BuildAndTrainModel(trainData);

                    var predictionEngine = RecommendationService.MLContext.Model.CreatePredictionEngine<UserPurchase, ProductPrediction>(model);

                    var currentDirectory = Directory.GetCurrentDirectory();

                    // Specify the subdirectory and model file name
                    var subdirectory = "TrainedModel"; 
                    var modelFileName = "trained_model.zip";

                    // Combine the current directory, subdirectory, and model file name
                    var modelFilePath = Path.Combine(currentDirectory, subdirectory, modelFileName);

                    // Create the subdirectory if it doesn't exist
                    Directory.CreateDirectory(Path.Combine(currentDirectory, subdirectory));

                    // Save the model
                    RecommendationService.MLContext.Model.Save(model, trainData.Schema, modelFilePath);


                    MarkAsComplete();
                }
        }

        protected override void ConfigureHowToFindSaga(SagaPropertyMapper<RecommendSagaData> mapper)
        {
            mapper.MapSaga(saga => saga.SagaId)
                .ToMessage<TrainRecommenderModelCommand>(msg => msg.SagaId).ToMessage<GetAllOrdersResponse>(msg => msg.SagaId).ToMessage<GetAllUsersResponse>(msg => msg.SagaId).ToMessage<GetAllProductItemsResponse>(msg => msg.SagaId);
        }


    }
}
