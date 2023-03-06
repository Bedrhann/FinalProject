using FinalProject.Application.DTOs.Category;
using FinalProject.Application.Features.CategoryFeatures.Commands.CreateCategory;
using FinalProject.Application.Features.CategoryFeatures.Commands.DeleteCategory;
using FinalProject.Application.Features.CategoryFeatures.Commands.UpdateCategory;
using FinalProject.Application.Features.CategoryFeatures.Queries.GetAllCategoryByShopList;
using FinalProject.Application.Features.CategoryFeatures.Queries.GetCategoryById;
using FinalProject.Application.Wrappers.Base;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace FinalProject.API.Controllers
{
    [Authorize(Roles = "User,Admin")]
    [Route("api/categories")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoriesController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllCategoryByShopList([FromQuery] GetAllCategoryByShopListQueryRequest request)
        {
            BaseResponse<List<CategoryQueryDto>> response = await _mediator.Send(request);

            return Ok(response);
        }



        [HttpGet("{Id}")]
        public async Task<IActionResult> GetCategoryById([FromRoute] GetCategoryByIdQueryRequest request)
        {
            BaseResponse<CategoryQueryDto> response = await _mediator.Send(request);

            return Ok(response);
        }

        

        [HttpPost]
        public async Task<IActionResult> CreateCategory([FromBody] CreateCategoryCommandRequest request)
        {
            BaseResponse<CategoryCreateDto> response = await _mediator.Send(request);

            return Ok(response);
        }



        [HttpPut]
        public async Task<IActionResult> UpdateCategory([FromBody] UpdateCategoryCommandRequest request)
        {
            BaseResponse<CategoryUpdateDto> response = await _mediator.Send(request);

            return Ok(response);
        }



        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteCategory([FromRoute] DeleteCategoryCommandRequest request)
        {
            BaseResponse<object> response = await _mediator.Send(request);

            return Ok(response);
        }
    }
}
