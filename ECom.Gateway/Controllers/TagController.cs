using AutoMapper;
using Dto.ProductDto;
using ECom.Gateway.Models;
using Messages;
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
        private readonly IMapper _mapper;
        public TagController(IMessageSession messageSession, IMapper mapper)
        {
            this.messageSession = messageSession;
            this._mapper = mapper;
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
                return ReturnWithStatus<Tag, TagDto>(response);
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
        public async Task<IActionResult> CreateTag(Tag newTag)
        {
            if (newTag == null)
            {
                return BadRequest();
            }
            try
            {
                TagDto newTagDto = _mapper.Map<TagDto>(newTag);
                var message = new CreateTag() { newTag = newTagDto };
                var response = await this.messageSession.Request<Response<TagDto>>(message);
                return ReturnWithStatus<Tag, TagDto>(response);
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpPatch]
        [EnableCors]
        [Route("{id}")]
        public async Task<IActionResult> UpdateTag(string id, Tag newTag)
        {
            int tagID = Int32.Parse(id);

            if (newTag == null)
            {
                return BadRequest();
            }
            try
            {
                TagDto newTagDto = _mapper.Map<TagDto>(newTag);
                var message = new UpdateTag() { newTag = newTagDto, Id = tagID };
                var response = await this.messageSession.Request<Response<TagDto>>(message);
                return ReturnWithStatus<Tag, TagDto>(response);
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
                return ReturnWithStatus<Tag, TagDto>(response);
            }
            catch
            {
                return StatusCode(500);
            }
        }
    }
}
