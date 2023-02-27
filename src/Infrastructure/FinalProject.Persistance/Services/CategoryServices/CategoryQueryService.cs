using FinalProject.Application.DTOs.Category;
using FinalProject.Application.Features.CategoryFeatures.Queries.GetAllCategoryByShopList;
using FinalProject.Application.Interfaces.Repositories.Common;
using FinalProject.Application.Interfaces.Services.CategoryService;
using FinalProject.Application.Wrappers.Base;
using FinalProject.Application.Wrappers.Paging;
using FinalProject.Domain.Entities;
using FinalProject.Persistance.Services.BaseServices;
using Mapster;
using Microsoft.Extensions.Caching.Distributed;
using System.Text;
using System.Text.Json;

namespace FinalProject.Persistance.Services.CategoryServices
{
    public class CategoryQueryService : BaseQueryService<CategoryQueryDto, Category>, ICategoryQueryService
    {
        private readonly IBaseQueryRepository<Category> _queryRepository;
        private readonly IDistributedCache _cache;
        private string _categoryCacheName;

        public CategoryQueryService(IBaseQueryRepository<Category> queryRepository, IDistributedCache cache) : base(queryRepository)
        {
            _queryRepository = queryRepository;
            _cache = cache;
        }

        public async Task<BaseResponse<List<CategoryQueryDto>>> GetAllAsync(GetAllCategoryByShopListQueryRequest request)
        {

            _categoryCacheName = request.ShopListId.ToString();
            var categoryCache = _cache.GetAsync(_categoryCacheName).Result;
            if(categoryCache != null)
            {
                var jsonCategory = Encoding.UTF8.GetString(categoryCache);
                List<CategoryQueryDto> categoryDtoList = JsonSerializer.Deserialize<List<CategoryQueryDto>>(jsonCategory);
                return new  BaseResponse<List<CategoryQueryDto>>(categoryDtoList);
            }
            else
            {
                List<Category> categories = _queryRepository.GetWhere(x => x.ShopListId == request.ShopListId).ToList();
                List<CategoryQueryDto> categoryDtoList = categories.Adapt<List<CategoryQueryDto>>();

                var cacheEntryOptions = new DistributedCacheEntryOptions()
                    .SetAbsoluteExpiration(TimeSpan.FromSeconds(85))
                    .SetSlidingExpiration(TimeSpan.FromSeconds(25));

                string jsonCategory = JsonSerializer.Serialize(categoryDtoList);
                await _cache.SetAsync(_categoryCacheName, Encoding.UTF8.GetBytes(jsonCategory), cacheEntryOptions);

                return new BaseResponse<List<CategoryQueryDto>>(categoryDtoList);
            }
        }
    }
}
