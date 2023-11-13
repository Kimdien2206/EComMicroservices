using Dto.ProductDto;
using Messages;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using NServiceBus.Logging;
using System.Collections;
using System.Net;
using ECom.Gateway.Models;
using AutoMapper;

namespace ECom.Gateway.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IMessageSession messageSession;
        static public ILog log = LogManager.GetLogger(typeof(ProductController));
        private readonly IMapper _mapper;

        public ProductController(IMessageSession messageSession, IMapper mapper)
        {
            this.messageSession = messageSession;
            this._mapper = mapper;
        }

        [HttpGet]
        [EnableCors]
        public async Task<IActionResult> GetAllProduct()
        {
            var cancellationTokenSource = new CancellationTokenSource();
            cancellationTokenSource.CancelAfter(TimeSpan.FromSeconds(5));
            log.Info("Received request");
            var message = new GetAllProduct();
            try
            {
                var response = await this.messageSession.Request<GetAllProductRes>(message, cancellationTokenSource.Token);
                log.Info($"Message sent, received: {response.productDtos}");
                return Ok(response.productDtos);
            }
            catch (OperationCanceledException ex)
            {
                log.Info("Message sent, but timeout");
                Request.HttpContext.Response.StatusCode = (int)HttpStatusCode.RequestTimeout;
                return StatusCode(500);
            }
        }

        [HttpGet]
        [Route("{id}")]
        [EnableCors]
        public async Task<IActionResult> GetProductByID(int productID)
        {
            if (productID == 0)
            {
                return BadRequest();
            }
            try
            {
                var message = new GetProductByID() { productID = productID };
                log.Info("Message sent, waiting for response");
                var response = await this.messageSession.Request<GetProductByIDRes>(message);
                return Ok(response);
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpPost]
        [EnableCors]
        [Route("/viewed")]

        public async Task<IActionResult> ViewProduct(int productID)
        {
            if(productID == 0)
            {
                return BadRequest();
            }
            try
            {
                var message = new ViewProduct() { productID = productID };
                await this.messageSession.Send(message);
                return Ok("Message sent, updating product");
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
                await this.messageSession.Send(message);
                return Ok("Message sent, adding product");
            }
            catch
            {
                return StatusCode(500);
            }
        }
    }
}
