using FinalProject.Application.DTOs.ShopList;
using FinalProject.Application.DTOs.User;
using FinalProject.Application.Features.UserFeatures.Queries.GetAllUser;
using FinalProject.Application.Interfaces.Repositories.ShopListRepositories;
using FinalProject.Application.Wrappers.Base;
using FinalProject.Persistance.Contexts;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json;

namespace FinalProject.API.Controllers
{
    //[Authorize(Roles = "Admin")]
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IArchiveShopListCommandRepository _repo;
        public UsersController(IMediator mediator,  IArchiveShopListCommandRepository repo)
        {
            _mediator = mediator;
            _repo = repo;
        }


        [HttpGet]
        [ResponseCache(Duration = 500, VaryByQueryKeys = new string[] { "Page", "Limit", })]
        public async Task<IActionResult> GetAllUsers([FromQuery] GetAllUserQueryRequest request)
        {
            BaseResponseWithPaging<List<UserQueryDto>> response = await _mediator.Send(request);
            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(response.PagingInfo));
            return Ok(response.BaseResponse);
        }

        [HttpGet("/add")]
        public async Task<IActionResult> GetDeneme([FromQuery] string request)
        {
            ArchivedShopList archivedShop = new()
            {
                description = "asdas",
                Name = "11111"
            };
            _repo.AddAsync(archivedShop);

            return Ok();
        }

        [HttpGet("/gett")]
        public async Task<IActionResult> GetDeneme2()
        {
            //var name = await _distributedCache.GetStringAsync("name");
            return Ok();
        }
    }
}
