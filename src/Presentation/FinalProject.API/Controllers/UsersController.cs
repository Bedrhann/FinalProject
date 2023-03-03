using FinalProject.Application.DTOs.User;
using FinalProject.Application.Features.UserFeatures.Queries.GetAllUser;
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
        private readonly IDistributedCache _distributedCache;
        public UsersController(IMediator mediator, IDistributedCache distributedCache)
        {
            _mediator = mediator;
            _distributedCache = distributedCache;
        }


        [HttpGet]
        [ResponseCache(Duration = 500, VaryByQueryKeys = new string[] { "Page", "Limit", })]
        public async Task<IActionResult> GetAllUsers([FromQuery] GetAllUserQueryRequest request)
        {
            if (request.UserId is not null)
            {
                if (_distributedCache.GetString(request.UserId) != null)
                {
                    return Ok(await _distributedCache.GetStringAsync(request.UserId));
                }
            }

            BaseResponseWithPaging<List<UserQueryDto>> response = await _mediator.Send(request);
            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(response.PagingInfo));
            await _distributedCache.SetStringAsync("user", response.BaseResponse.Response.ToString(), options: new()
            {
                AbsoluteExpiration = DateTime.UtcNow.AddSeconds(20),
                SlidingExpiration = TimeSpan.FromSeconds(6),
            });
            return Ok(response.BaseResponse);
        }
        public class Product
        {
            [BsonId]
            public ObjectId Id { get; set; }
            public string name { get; set; }
            public string surname { get; set; }

        }

        [HttpGet("/add")]
        public async Task<IActionResult> GetDeneme([FromQuery] string request)
        {
            MongoDbConnect dbConnect = new();

            Product product = new Product()
            {
                name = "CEMALETTİN",
                surname = "KOYA"
            };
            var collection = dbConnect.ConnectToMongo<Product>("products");
            await collection.InsertOneAsync(product);
            return Ok();
        }

        [HttpGet("/gett")]
        public async Task<IActionResult> GetDeneme2()
        {
            var name = await _distributedCache.GetStringAsync("name");
            return Ok(name);
        }
    }
}
