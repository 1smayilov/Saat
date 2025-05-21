using Application.Features.Commands.Products.CreateProduct;
using Application.Features.Commands.Products.RemoveProduct;
using Application.Features.Commands.Products.UpdateProduct;
using Application.Features.Queries.Products.GetAllProduct;
using Application.Features.Queries.Products.GetByIdProduct;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        readonly IMediator _mediator;
        readonly IWebHostEnvironment _webHostEnvironment;

        public ProductController(IMediator mediator, IWebHostEnvironment webHostEnvironment)
        {
            _mediator = mediator;
            _webHostEnvironment = webHostEnvironment;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllProducts([FromQuery] GetAllProductQueryRequest request) 
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetByIdProduct([FromRoute] GetByIdProductQueryRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductCommandRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProduct(UpdateProductCommandRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveProduct(RemoveProductCommandRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        //[HttpPost("UploadImages")]
        //public async Task<IActionResult> Upload()
        //{
        //    string uploadPath = Path.Combine(_webHostEnvironment.WebRootPath, "product-images");
        //    foreach(IFormFile file in Request.Form.Files)
        //    {

        //    }
        //}
    }
}
