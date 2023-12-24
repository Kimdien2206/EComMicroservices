using AutoMapper;
using ECom.Services.Forecasts.Utility;
using Messages.ForecastMessage;
using Messages.ProductMessages;
using Messages.ReportMessages;
using Microsoft.IdentityModel.Tokens;
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

        public Task Handle(TrainForecastCommand message, IMessageHandlerContext context)
        {
            try
            {
                // get all product
                context.Send(new GetAllProductId() { SagaId = message.SagaId }).ConfigureAwait(false);
                // get report detail daily
                context.Send(new GetAllDailyDetailReport() { SagaId = message.SagaId }).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                log.Error($"Error: {ex.Message}");
                log.Error(ex.StackTrace);
            }
            return Task.CompletedTask;
        }

        public async Task Handle(GetAllProductIdResponse message, IMessageHandlerContext context)
        {
            log.Info($"Forecast saga {message.SagaId} received {message.ProductIds.Count} product ids");
            this.Data.Products = message.ProductIds;

            await ProcessForecast(context);
        }

        private async Task ProcessForecast(IMessageHandlerContext context)
        {
            if (!this.Data.Products.IsNullOrEmpty() && !this.Data.DailyReports.IsNullOrEmpty())
            {
                // so some training and forecast
                log.Info($"Forecast saga {this.Data.SagaId} completed {this.Data.DailyReports.Count} dailyreport and {this.Data.Products.Count} product ids");

                MarkAsComplete();
            }
        }

        public async Task Handle(GetAllDailyDetailReportSaga message, IMessageHandlerContext context)
        {
            log.Info($"Forecast saga {message.SagaId} received {message.Forecasts.Count} product ids");
            this.Data.DailyReports = message.Forecasts;

            await ProcessForecast(context);
        }
    }
}
