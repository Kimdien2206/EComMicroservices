using System.Net;
using Dto.ProductDto;
using Messages;
using Messages.ProductMessages;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using NServiceBus.Logging;

namespace ECom.Gateway.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : BaseController
    {
        private readonly IMessageSession messageSession;
        private readonly ILog log = LogManager.GetLogger(typeof(ProductController));

        public ProductController(IMessageSession messageSession)
        {
            this.messageSession = messageSession;
        }

        [HttpGet]
        [EnableCors]
        public async Task<IActionResult> GetAllProducts()
        {
            //var cancellationTokenSource = new CancellationTokenSource();
            //cancellationTokenSource.CancelAfter(TimeSpan.FromSeconds(5));
            log.Info("Received request");
            var message = new GetAllProduct();
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

        [HttpGet]
        [Route("slug/{slug}")]
        [EnableCors]
        [AllowAnonymous]
        public async Task<IActionResult> GetProductsBySlug(string slug)
        {
            if (slug == null)
            {
                return BadRequest();
            }
            try
            {
                var message = new GetProductBySlug() { ProductSlug = slug };
                log.Info("Message sent, waiting for response");
                var response = await this.messageSession.Request<Response<ProductDto>>(message);
                return ReturnWithStatus(response);
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpGet]
        [Route("best-sellers")]
        public async Task<IActionResult> GetBestSellersProducts()
        {
            try
            {
                var message = new GetBestSellers();
                log.Info("Message GetBestSellers sent, waiting for response");
                var response = await this.messageSession.Request<Response<ProductDto>>(message);
                return ReturnWithStatus(response);
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpGet]
        [Route("most-viewed")]
        [EnableCors]

        public async Task<IActionResult> GetMostViewedProducts()
        {
            try
            {
                var message = new GetMostViewed();
                log.Info("Message GetMostViewed sent, waiting for response");
                var response = await this.messageSession.Request<Response<ProductDto>>(message);
                return ReturnWithStatus(response);
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpPatch]
        [Route("viewed/{id}")]
        [EnableCors]
        public async Task<IActionResult> ViewProduct(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            try
            {
                var message = new ViewProduct() { productID = id };
                var response = await this.messageSession.Request<Response<ProductDto>>(message);
                return ReturnWithStatus(response);
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpPost]
        [EnableCors]

        public async Task<IActionResult> CreateProduct(ProductDto newProduct)
        {
            if (newProduct == null)
            {
                return BadRequest();
            }
            try
            {
                var message = new CreateProduct() { newProduct = newProduct };
                var response = await this.messageSession.Request<Response<ProductDto>>(message);
                return ReturnWithStatus(response);
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpPut]
        [EnableCors]
        [Route("{id}")]
        public async Task<IActionResult> UpdateProduct(ProductDto newProduct, string id)
        {
            if (newProduct == null || id == null)
            {
                return BadRequest();
            }
            int productId = Int32.Parse(id);
            try
            {
                var message = new UpdateProduct() { product = newProduct, Id = productId };
                var response = await this.messageSession.Request<Response<ProductDto>>(message);
                return ReturnWithStatus(response);
            }
            catch
            {
                return StatusCode(500);
            }
        }

    }
}
