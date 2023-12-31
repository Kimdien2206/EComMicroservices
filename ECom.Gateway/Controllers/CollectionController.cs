using System.Net;
using Dto.ProductDto;
using Messages;
using Messages.CollectionMessages;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using NServiceBus.Logging;

namespace ECom.Gateway.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CollectionController : BaseController
    {
        private readonly IMessageSession messageSession;
        private readonly ILog log = LogManager.GetLogger(typeof(CollectionController));
        public CollectionController(IMessageSession messageSession)
        {
            this.messageSession = messageSession;
        }

        [HttpGet]
        [EnableCors]
        public async Task<IActionResult> GetAllCollection()
        {
            //var cancellationTokenSource = new CancellationTokenSource();
            //cancellationTokenSource.CancelAfter(TimeSpan.FromSeconds(5));
            log.Info("Received request");
            var message = new GetAllCollection();
            try
            {
                var response = await this.messageSession.Request<Response<CollectionDto>>(message);
                log.Info($"Message sent, received: {response.responseData}");
                return ReturnWithStatus(response);
            }
            catch (OperationCanceledException ex)
            {
                log.Info($"Message sent, but {ex}");
                Request.HttpContext.Response.StatusCode = (int)HttpStatusCode.RequestTimeout;
                return StatusCode(500);
            }
        }

        [HttpGet]
        [Route("{id}")]
        [EnableCors]
        public async Task<IActionResult> GetProductOfCollection(string id)
        {
            log.Info("Received request");
            if (id == null)
            {
                return BadRequest();
            }
            else
            {
                int collectionID = Int32.Parse(id);
                var message = new GetProductOfCollection() { Id = collectionID };
                try
                {
                    var response = await this.messageSession.Request<Response<ProductDto>>(message);
                    log.Info($"Message sent, received: {response.responseData}");
                    return ReturnWithStatus(response);
                }
                catch (OperationCanceledException ex)
                {
                    log.Info($"Message sent, but {ex}");
                    Request.HttpContext.Response.StatusCode = (int)HttpStatusCode.RequestTimeout;
                    return StatusCode(500);
                }
            }
        }

        [HttpPost]
        [EnableCors]
        public async Task<IActionResult> CreateCollection(CollectionDto newCollection)
        {
            if (newCollection == null)
            {
                return BadRequest();
            }
            try
            {
                var message = new CreateCollection() { newCollection = newCollection };
                var response = await this.messageSession.Request<Response<CollectionDto>>(message);
                return ReturnWithStatus<CollectionDto>(response);
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpPut]
        [EnableCors]
        [Route("{id}")]
        public async Task<IActionResult> UpdateCollection(string id, CollectionDto newCollection)
        {
            int collectionID = Int32.Parse(id);

            if (newCollection == null)
            {
                return BadRequest();
            }
            try
            {
                var message = new UpdateCollection() { collection = newCollection, id = collectionID };
                var response = await this.messageSession.Request<Response<CollectionDto>>(message);
                return ReturnWithStatus<CollectionDto>(response);
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpDelete]
        [EnableCors]
        [Route("{id}")]
        public async Task<IActionResult> DeleteCollection(string id)
        {
            int collectionID = Int32.Parse(id);
            if (collectionID == 0)
            {
                return BadRequest();
            }
            try
            {
                var message = new DeleteCollection() { Id = collectionID };
                var response = await this.messageSession.Request<Response<CollectionDto>>(message);
                return ReturnWithStatus<CollectionDto>(response);
            }
            catch
            {
                return StatusCode(500);
            }
        }
    }
}
