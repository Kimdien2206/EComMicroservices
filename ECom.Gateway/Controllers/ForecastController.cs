using Dto.ForecastDto;
using Messages;
using Messages.ForecastMessage;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using NServiceBus.Logging;

namespace ECom.Gateway.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ForecastController : BaseController
    {
        private readonly IMessageSession messageSession;
        private readonly ILog log = LogManager.GetLogger(typeof(ForecastController));
        public ForecastController(IMessageSession messageSession)
        {
            this.messageSession = messageSession;
        }

        [HttpGet]
        [EnableCors]
        [Route("{id}")]
        public async Task<IActionResult> getForecastByProductId(int id)
        {
            if (id == null)
                return BadRequest();

            try
            {
                var message = new GetForecastByProductId()
                {
                    Id = id
                };

                var respond = await messageSession.Request<Response<ForecastDto>>(message);

                return ReturnWithStatus(respond);
            }
            catch (Exception ex)
            {
                log.Error($"Error {ex.Message}");
                log.Error(ex.StackTrace);
                return StatusCode(500);
            }
        }

        [HttpPost]
        [EnableCors]
        public async Task<IActionResult> forecastForAllProduct()
        {
            try
            {
                string uuid = Guid.NewGuid().ToString();
                var trainCmd = new TrainForecastCommand() { SagaId = uuid };
                var respond = await messageSession.Request<Response<string>>(trainCmd);

                return ReturnWithStatus<string>(respond);
            }
            catch (Exception ex)
            {
                log.Error($"Error {ex.Message}");
                log.Error(ex.StackTrace);
                return StatusCode(500);
            }
        }
    }
}
