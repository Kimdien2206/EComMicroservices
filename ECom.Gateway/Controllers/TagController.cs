using Dto.ProductDto;
using Messages;
using Messages.ProductMessages;
using Messages.TagMessages;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using NServiceBus.Logging;
using System.Net;

namespace ECom.Gateway.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TagController : BaseController
    {

        private readonly IMessageSession messageSession;
        private readonly ILog log = LogManager.GetLogger(typeof(TagController));
        public TagController(IMessageSession messageSession)
        {
            this.messageSession = messageSession;
        }

        [HttpGet]
        [EnableCors]
        public async Task<IActionResult> GetAllTag()
        {
            //var cancellationTokenSource = new CancellationTokenSource();
            //cancellationTokenSource.CancelAfter(TimeSpan.FromSeconds(5));
            log.Info("Received request");
            var message = new GetAllTag();
            try
            {
                var response = await this.messageSession.Request<Response<TagDto>>(message);
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
        [Route("product/{tagId}")]
        [EnableCors]
        public async Task<IActionResult> GetProductByTagID(string tagId)
        {
            if(tagId == null)
            {
                return BadRequest();
            }
            else
            {
                int id = Int32.Parse(tagId);
                var message = new GetProductByTagId() { TagID = id };
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
        public async Task<IActionResult> CreateTag(TagDto newTag)
        {
            if (newTag == null)
            {
                return BadRequest();
            }
            try
            {
                var message = new CreateTag() { newTag = newTag };
                var response = await this.messageSession.Request<Response<TagDto>>(message);
                return ReturnWithStatus(response);
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpPatch]
        [EnableCors]
        [Route("{id}")]
        public async Task<IActionResult> UpdateTag(string id, TagDto newTag)
        {
            int tagID = Int32.Parse(id);

            if (newTag == null)
            {
                return BadRequest();
            }
            try
            {
                var message = new UpdateTag() { newTag = newTag, Id = tagID };
                var response = await this.messageSession.Request<Response<TagDto>>(message);
                return ReturnWithStatus (response);
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpDelete]
        [EnableCors]
        [Route("{id}")]
        public async Task<IActionResult> DeleteTag(string id)
        {
            int tagID = Int32.Parse(id);
            if (tagID == 0)
            {
                return BadRequest();
            }
            try
            {
                var message = new DeleteTag() { Id = tagID };
                var response = await this.messageSession.Request<Response<TagDto>>(message);
                return ReturnWithStatus(response);
            }
            catch
            {
                return StatusCode(500);
            }
        }
    }
}
