using AutoMapper;
using Dto.ReportDto;
using Ecom.Services.Forecasts.Models;
using Ecom.Services.Forecasts.Service;
using ECom.Services.Forecasts.Data;
using ECom.Services.Forecasts.Utility;
using Messages;
using Messages.ForecastMessage;
using Messages.ProductMessages;
using Messages.ReportMessages;
using Microsoft.IdentityModel.Tokens;
using Microsoft.ML;
using Microsoft.ML.Transforms.TimeSeries;
using NServiceBus.Logging;
using SagaData.Forecast;

namespace Ecom.Services.Forecast.Handler
{
    public class ForecastSagaHandler : Saga<ForecastSagaData>,
        IAmStartedByMessages<TrainForecastCommand>,
        IAmStartedByMessages<GetAllProductIdResponse>,
        IAmStartedByMessages<GetAllDailyDetailReportSaga>
    {
        static ILog log = LogManager.GetLogger<ForecastHandler>();
        private IMapper mapper;

        public ForecastSagaHandler()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
            });
            this.mapper = config.CreateMapper();
        }

        protected override void ConfigureHowToFindSaga(SagaPropertyMapper<ForecastSagaData> mapper)
        {
            mapper.MapSaga(saga => saga.SagaId)
                .ToMessage<GetAllProductIdResponse>(mess => mess.SagaId)
                .ToMessage<TrainForecastCommand>(msg => msg.SagaId)
                .ToMessage<GetAllDailyDetailReportSaga>(msg => msg.SagaId);
        }

        public async Task Handle(TrainForecastCommand message, IMessageHandlerContext context)
        {
            var response = new Response<string>() { ErrorCode = 200 };
            try
            {
                // get all product
                await context.Send(new GetAllProductId() { SagaId = message.SagaId });
                // get report detail daily
                await context.Send(new GetAllDailyDetailReport() { SagaId = message.SagaId });
            }
            catch (Exception ex)
            {
                log.Error($"Error: {ex.Message}");
                log.Error(ex.StackTrace);
                response.ErrorCode = 500;
            }
            await context.Reply(response);
        }

        public async Task Handle(GetAllProductIdResponse message, IMessageHandlerContext context)
        {
            log.Info($"Forecast saga {message.SagaId} received {message.ProductIds.Count} product ids");
            this.Data.Products = message.ProductIds;

            await processForecast(context);
        }

        public async Task Handle(GetAllDailyDetailReportSaga message, IMessageHandlerContext context)
        {
            log.Info($"Forecast saga {message.SagaId} received {message.Forecasts.Count} forecast");
            this.Data.DailyReports = message.Forecasts;

            await processForecast(context);
        }

        private async Task processForecast(IMessageHandlerContext context)
        {
            if (!this.Data.Products.IsNullOrEmpty() && !this.Data.DailyReports.IsNullOrEmpty())
            {
                // so some training and forecast
                log.Info($"Forecast saga {this.Data.SagaId} completed {this.Data.DailyReports.Count} dailyreport and {this.Data.Products.Count} product ids");

                buildAndTrain(this.Data.Products, this.Data.DailyReports);

                MarkAsComplete();
            }

        }

        private void buildAndTrain(List<int> productIdsDtos, List<DailyReportDetailDto> dailyReportDetailDtos)
        {
            foreach (var productId in productIdsDtos)
            {
                var trainData = dailyReportDetailDtos.Where(dailyRp => dailyRp.ProductId == productId).ToList();
                // if dont have any data so training is meaningless
                if (trainData.Count > 0)
                {
                    var trainDataView = ForecastService.ConvertData(trainData);
                    ITransformer model = ForecastService.BuildAndTrainModel(trainDataView);

                    var forecastEngine = model.CreateTimeSeriesEngine<ModelInput, ModelOutput>(ForecastService.MLContext);

                    var forecastSolds = ForecastService.ForecastNextDays(forecastEngine);

                    var forecast = DataAccess.Ins.DB.Forecasts.FirstOrDefault(fc => fc.ProductId == productId);

                    if (forecast == null)
                    {
                        forecast = new Forecasts.Models.Forecast() { LastUpdated = DateOnly.FromDateTime(DateTime.Now), ProductId = productId };
                        DataAccess.Ins.DB.Forecasts.Add(forecast);
                    }
                    else
                    {
                        forecast.LastUpdated = DateOnly.FromDateTime(DateTime.Now);
                    }

                    var forecastDetails = new List<ForecastDetail>();

                    for (int i = 0; i < forecastSolds.Length; i++)
                    {
                        forecastDetails.Add(new ForecastDetail() { ForecastId = forecast.Id, TotalSold = ((int)forecastSolds[i]), date = DateOnly.FromDateTime(DateTime.Now.AddDays(i + 1)) });
                    }

                    DataAccess.Ins.DB.ForecastDetails.AddRange(forecastDetails);
                }
            }

            DataAccess.Ins.DB.SaveChanges();
        }
    }
}
