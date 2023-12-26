using AutoMapper;
using Dto.ForecastDto;
using ECom.Services.Forecasts.Data;
using ECom.Services.Forecasts.Utility;
using Messages;
using Messages.ForecastMessage;
using NServiceBus.Logging;

namespace Ecom.Services.Forecast.Handler
{
    public class ForecastHandler : IHandleMessages<GetForecastByProductId>
    {
        static ILog log = LogManager.GetLogger<ForecastHandler>();
        private IMapper mapper;

        public ForecastHandler()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
            });
            this.mapper = config.CreateMapper();
        }

        public async Task Handle(GetForecastByProductId message, IMessageHandlerContext context)
        {
            var respond = new Response<ForecastDto>();

            try
            {
                var forecast = DataAccess.Ins.DB.Forecasts.FirstOrDefault(forecastTemp => forecastTemp.ProductId == message.Id);

                if (forecast != null)
                {
                    var forecastDetails = DataAccess.Ins.DB.ForecastDetails.Where(ele => ele.ForecastId == forecast.Id).OrderByDescending(ele => ele.date).Take(31).ToList();
                    log.Info($"forecast detail count: {forecastDetails.Count}");
                    if (forecastDetails.Count > 0)
                    {
                        var forecastRes = new ForecastDto()
                        {
                            Id = forecast.Id,
                            LastUpdated = forecast.LastUpdated,
                            ProductId = forecast.ProductId,
                            Details = forecastDetails.Select((ele) => mapper.Map<ForecastDetailDto>(ele)).ToList()
                        };
                        respond.responseData = new List<ForecastDto>() { forecastRes };
                        Console.WriteLine($"Get data count: {respond.responseData.Count()}");
                        respond.ErrorCode = 200;
                    }
                    else
                    {
                        respond.ErrorCode = 404;
                    }

                }
                else
                {
                    respond.ErrorCode = 404;
                }
            }
            catch (Exception ex)
            {
                log.Error($"Error: {ex.Message}");
                log.Error(ex.StackTrace);
                respond.ErrorCode = 500;
            }

            await context.Reply(respond);
        }
    }
}
