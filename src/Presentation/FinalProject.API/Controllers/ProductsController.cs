using FinalProject.Application.DTOs.Product;
using FinalProject.Application.Features.ProductFeatures.Commands.CreateProduct;
using FinalProject.Application.Features.ProductFeatures.Commands.DeleteProduct;
using FinalProject.Application.Features.ProductFeatures.Commands.UpdateProduct;
using FinalProject.Application.Features.ProductFeatures.Queries.GetAllProductByCategory;
using FinalProject.Application.Features.ProductFeatures.Queries.GetProductById;
using FinalProject.Application.Wrappers.Base;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace FinalProject.API.Controllers
{
    [Authorize(Roles = "User,Admin")]
    [Route("api/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllProductByShopList([FromQuery] GetAllProductByCategoryQueryRequest request)
        {
            BaseResponseWithPaging<List<ProductQueryDto>> response = await _mediator.Send(request);
            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(response.PagingInfo));

            return Ok(response.BaseResponse);
        }




        [HttpGet("{Id}")]
        public async Task<IActionResult> GetProductById([FromRoute] GetProductByIdQueryRequest request)
        {
            BaseResponse<ProductQueryDto> response = await _mediator.Send(request);

            return Ok(response);
        }




        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] CreateProductCommandRequest request)
        {
            BaseResponse<ProductCreateDto> response = await _mediator.Send(request);

            return Ok(response);
        }




        [HttpPut]
        public async Task<IActionResult> UpdateProduct([FromBody] UpdateProductCommandRequest request)
        {
            BaseResponse<ProductUpdateDto> response = await _mediator.Send(request);

            return Ok(response);
        }




        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteProduct([FromRoute] DeleteProductCommandRequest request)
        {
            BaseResponse<object> response = await _mediator.Send(request);

            return Ok(response);
        }
    }
}
