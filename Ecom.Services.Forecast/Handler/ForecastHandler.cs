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
                var forecasts = DataAccess.Ins.DB.Forecasts.Where(forecast => forecast.ProductId == message.Id).ToList();

                respond.responseData = forecasts.Select(forecast => mapper.Map<ForecastDto>(forecast));
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
