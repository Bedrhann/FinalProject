using FinalProject.Application.DTOs.ShopList;
using FinalProject.Application.Features.ShopListFeatures.Commands.CreateShopList;
using FinalProject.Application.Features.ShopListFeatures.Commands.DeleteShopList;
using FinalProject.Application.Features.ShopListFeatures.Commands.UpdateShopList;
using FinalProject.Application.Features.ShopListFeatures.Queries.GetAllShopList;
using FinalProject.Application.Features.ShopListFeatures.Queries.GetAllShopListByUser;
using FinalProject.Application.Features.ShopListFeatures.Queries.GetShopListById;
using FinalProject.Application.Wrappers.Base;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Text.Json;

namespace FinalProject.API.Controllers
{
    [Authorize(Roles = "User,Admin")]
    [Route("api/mylists")]
    [ApiController]
    public class ShopListsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ShopListsController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllShopListByUser([FromQuery] GetAllShopListByUserQueryRequest request)
        {
            ClaimsIdentity Identity = (ClaimsIdentity)HttpContext.User.Identity;
            request.UserId = Guid.Parse(Identity.Claims.FirstOrDefault(x => x.Type == "Id").Value);//Gelen token'ın içinden Id değerine göre kullanıcıyı belirleyip ona göre listesini döndürüyoruz.
            BaseResponseWithPaging<List<ShopListQueryDto>> response = await _mediator.Send(request);
            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(response.PagingInfo));
            return Ok(response.BaseResponse);
        }




        [HttpGet("{Id}")]
        public async Task<IActionResult> GetShopListById([FromRoute] GetShopListByIdQueryRequest request)
        {
            BaseResponse<ShopListQueryDto> response = await _mediator.Send(request);
            return Ok(response);
        }



        [HttpPost]
        public async Task<IActionResult> CreateShopList(CreateShopListCommandRequest request)
        {
            ClaimsIdentity Identity = (ClaimsIdentity)HttpContext.User.Identity;
            request.AppUserId = Guid.Parse(Identity.Claims.FirstOrDefault(x => x.Type == "Id").Value);
            BaseResponse<ShopListCommandDto> response = await _mediator.Send(request);

            return Ok(response);
        }



        [HttpPut]
        public async Task<IActionResult> UpdateShopList([FromBody] UpdateShopListCommandRequest request)
        {
            BaseResponse<ShopListCommandDto> response = await _mediator.Send(request);

            return Ok(response);
        }



        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeletedShopList([FromRoute] DeleteShopListCommandRequest request)
        {

            BaseResponse<ShopListCommandDto> response = await _mediator.Send(request);

            return Ok(response);
        }



        [Authorize(Roles = "Admin")]
        [HttpGet("admin/lists-of-all-user")]
        public async Task<IActionResult> GetAllShopList([FromQuery] GetAllShopListQueryRequest request)
        {
            BaseResponseWithPaging<List<ShopListQueryDto>> response = await _mediator.Send(request);

            return Ok(response);
        }



        [Authorize(Roles = "Admin")]
        [HttpGet("admin/archive-shopList")]
        public async Task<IActionResult> GetAllArchiveShopList([FromQuery] GetAllShopListQueryRequest request)
        {
            BaseResponseWithPaging<List<ShopListQueryDto>> response = await _mediator.Send(request);

            return Ok(response);
        }
    }
}
