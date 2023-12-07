using Dto.ProductDto;
using Messages;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using NServiceBus.Logging;
using System.Collections;
using System.Net;
using ECom.Gateway.Models;
using AutoMapper;
using Messages.ProductMessages;

namespace ECom.Gateway.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : BaseController
    {
        private readonly IMessageSession messageSession;
        private readonly ILog log = LogManager.GetLogger(typeof(ProductController));
        private readonly IMapper _mapper;

        public ProductController(IMessageSession messageSession, IMapper mapper)
        {
            this.messageSession = messageSession;
            this._mapper = mapper;
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
                return ReturnWithStatus<ProductDto>(response);
            }
            catch (OperationCanceledException ex)
            {
                log.Info($"Message sent, but {ex}");
                Request.HttpContext.Response.StatusCode = (int)HttpStatusCode.RequestTimeout;
                return StatusCode(500);
            }
        }

        [HttpGet]
        [Route("{slug}")]
        [EnableCors]
        public async Task<IActionResult> GetProductsBySlug(string slug)
        {
            if (slug == null)
            {
                return BadRequest();
            }
            try
            {
                var message = new GetProductBySlug() { productSlug = slug };
                log.Info("Message sent, waiting for response");
                var response = await this.messageSession.Request<Response<ProductDto>>(message);
                return ReturnWithStatus<ProductDto>(response);
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
                log.Info("Message sent, waiting for response");
                var response = await this.messageSession.Request<Response<ProductDto>>(message);
                return ReturnWithStatus<ProductDto>(response);
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpGet]
        [Route("most-viewed")]
        public async Task<IActionResult> GetMostViewedProducts()
        {
            try
            {
                var message = new GetMostViewed();
                log.Info("Message sent, waiting for response");
                var response = await this.messageSession.Request<Response<ProductDto>>(message);
                return ReturnWithStatus<ProductDto>(response);
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpPatch]
        [Route("viewed")]
        [EnableCors]
        public async Task<IActionResult> ViewProduct(int productID)
        {
            if(productID == 0)
            {
                return BadRequest();
            }
            try
            {
                var message = new ViewProduct() { productID = productID };
                var response = await this.messageSession.Request<Response<ProductDto>>(message);
                return ReturnWithStatus<ProductDto>(response);
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpPost]
        [EnableCors]
        public async Task<IActionResult> CreateProduct(Product newProduct)
        {
            if (newProduct == null)
            {
                return BadRequest();
            }
            try
            {
                ProductDto newProductDto = _mapper.Map<ProductDto>(newProduct);
                var message = new CreateProduct() { newProduct = newProductDto };
                var response = await this.messageSession.Request<Response<ProductDto>>(message);
                return ReturnWithStatus<ProductDto>(response);
            }
            catch
            {
                return StatusCode(500);
            }
        }
        
        [HttpPatch]
        [EnableCors]
        [Route("{id}")]
        public async Task<IActionResult> UpdateProduct(Product newProduct)
        {
            if (newProduct == null)
            {
                return BadRequest();
            }
            try
            {
                ProductDto newProductDto = _mapper.Map<ProductDto>(newProduct);
                var message = new UpdateProduct() { product = newProductDto, Id = newProductDto.Id };
                var response = await this.messageSession.Request<Response<ProductDto>>(message);
                return ReturnWithStatus<ProductDto>(response);
            }
            catch
            {
                return StatusCode(500);
            }
        }

    }
}
