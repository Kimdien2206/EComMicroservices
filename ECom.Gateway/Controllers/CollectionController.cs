using AutoMapper;
using Dto.ProductDto;
using ECom.Gateway.Models;
using Messages;
using Messages.CollectionMessages;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using NServiceBus.Logging;
using System.Net;

namespace ECom.Gateway.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CollectionController : BaseController
    {
        private readonly IMessageSession messageSession;
        private readonly ILog log = LogManager.GetLogger(typeof(CollectionController));
        private readonly IMapper _mapper;
        public CollectionController(IMessageSession messageSession, IMapper mapper)
        {
            this.messageSession = messageSession;
            this._mapper = mapper;
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
                return ReturnWithStatus<Collection, CollectionDto>(response);
            }
            catch (OperationCanceledException ex)
            {
                log.Info($"Message sent, but {ex}");
                Request.HttpContext.Response.StatusCode = (int)HttpStatusCode.RequestTimeout;
                return StatusCode(500);
            }
        }

        [HttpPost]
        [EnableCors]
        public async Task<IActionResult> CreateCollection(Collection newCollection)
        {
            if (newCollection == null)
            {
                return BadRequest();
            }
            try
            {
                CollectionDto newCollectionDto = _mapper.Map<CollectionDto>(newCollection);
                var message = new CreateCollection() { newCollection = newCollectionDto };
                var response = await this.messageSession.Request<Response<CollectionDto>>(message);
                return ReturnWithStatus<Collection, CollectionDto>(response);
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpPatch]
        [EnableCors]
        [Route("{id}")]
        public async Task<IActionResult> UpdateCollection(string id, Collection newCollection)
        {
            int collectionID = Int32.Parse(id);

            if (newCollection == null)
            {
                return BadRequest();
            }
            try
            {
                CollectionDto newCollectionDto = _mapper.Map<CollectionDto>(newCollection);
                var message = new UpdateCollection() { collection = newCollectionDto, id = collectionID };
                var response = await this.messageSession.Request<Response<CollectionDto>>(message);
                return ReturnWithStatus<Collection, CollectionDto>(response);
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
                return ReturnWithStatus<Collection, CollectionDto>(response);
            }
            catch
            {
                return StatusCode(500);
            }
        }
    }
}
