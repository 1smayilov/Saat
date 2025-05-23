using Application.Features.Commands.Products.CreateProduct;
using Application.Features.Commands.Products.RemoveProduct;
using Application.Features.Commands.Products.UpdateProduct;
using Application.Features.Queries.Products.GetAllProduct;
using Application.Features.Queries.Products.GetAllProductWithAll;
using Application.Features.Queries.Products.GetByIdProduct;
using Application.Services;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllProducts([FromQuery] GetAllProductQueryRequest request) 
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("GetAllProductsWith")]
        public async Task<IActionResult> GetAllProductsWith([FromQuery] GetAllProductWithAllQueryRequest request)
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

        [HttpDelete("{Id}")]
        public async Task<IActionResult> RemoveProduct(RemoveProductCommandRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        
    }
}
