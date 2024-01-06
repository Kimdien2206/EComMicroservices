using Dto.ProductDto;
using Messages;
using Messages.ProductMessages;
using Messages.RecommendMessages;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using NServiceBus.Logging;

namespace ECom.Gateway.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RecommenderController : BaseController
    {
        private readonly IMessageSession messageSession;
        private readonly ILog log = LogManager.GetLogger(typeof(RecommenderController));
        public RecommenderController(IMessageSession messageSession)
        {
            this.messageSession = messageSession;
        }

        [HttpGet]
        [EnableCors]
        [Route("{productId}")]
        public async Task<IActionResult> getRecommendedProductByProductId(int productId)
        {
            if (productId == null)
                return BadRequest();
            // THIS CODE NEED TO OPTIMIZE !!!
            try
            {
                var getAllProductMsg = new GetAllProduct();
                var getAllProductResponse = await this.messageSession.Request<Response<ProductDto>>(getAllProductMsg);

                List<int> productIds = new List<int>();

                if (getAllProductResponse.responseData.IsNullOrEmpty())
                    return Problem("Product data is not available");


                foreach (var item in getAllProductResponse.responseData)
                {
                    productIds.Add(item.Id);
                }

                var message = new GetRecommendedProductCommand()
                {
                    ProductId = productId,
                    ProductIds = productIds
                };
                var recommendedProductRes = await messageSession.Request<Response<int>>(message);

                if (recommendedProductRes.ErrorCode == 200)
                {
                    var resultRes = new Response<ProductDto>();

                    resultRes.ErrorCode = recommendedProductRes.ErrorCode;
                    resultRes.responseData = getAllProductResponse.responseData.Where(pro => recommendedProductRes.responseData.Contains(pro.Id)).ToList();
                    return ReturnWithStatus(resultRes);
                }
                else
                {
                    return StatusCode(200);
                }


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
        public async Task<IActionResult> trainRecommender()
        {
            try
            {
                string uuid = Guid.NewGuid().ToString();
                var trainCmd = new TrainRecommenderModelCommand() { SagaId = uuid };
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
