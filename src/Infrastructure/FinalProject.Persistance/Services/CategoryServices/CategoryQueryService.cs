using FinalProject.Application.DTOs.Category;
using FinalProject.Application.Features.CategoryFeatures.Queries.GetAllCategoryByShopList;
using FinalProject.Application.Interfaces.Repositories.Common;
using FinalProject.Application.Interfaces.Services.CategoryService;
using FinalProject.Application.Wrappers.Base;
using FinalProject.Application.Wrappers.Paging;
using FinalProject.Domain.Entities;
using FinalProject.Persistance.Services.BaseServices;
using Mapster;

namespace FinalProject.Persistance.Services.CategoryServices
{
    public class CategoryQueryService : BaseQueryService<CategoryQueryDto, Category>, ICategoryQueryService
    {
        private readonly IBaseQueryRepository<Category> _queryRepository;

        public CategoryQueryService(IBaseQueryRepository<Category> queryRepository) : base(queryRepository)
        {
            _queryRepository = queryRepository;
        }

        public async Task<BaseResponseWithPaging<List<CategoryQueryDto>>> GetAllAsync(GetAllCategoryByShopListQueryRequest request)
        {
            IQueryable<Category> Categories = _queryRepository.GetWhere(x => x.ShopListId == request.ShopListId);

            if (!string.IsNullOrWhiteSpace(request.SearchByName))
            {
                Categories = Categories.Where(x => x.Name.Contains(request.SearchByName));
            }

            if (request.CreationRangeCeiling.HasValue || request.CreationRangeLower.HasValue)
            {
                Categories = Categories.Where(x => x.CreationDate <= request.CreationRangeCeiling && x.CreationDate >= request.CreationRangeLower);
            }

            if (request.UpdateRangeCeiling.HasValue || request.UpdateRangeLower.HasValue)
            {
                Categories = Categories.Where(x => x.UpdateDate <= request.UpdateRangeCeiling && x.UpdateDate >= request.UpdateRangeLower);
            }

            int TotalUser = Categories.Count();
            int TotalPage = (int)Math.Ceiling(TotalUser / (double)request.Limit);
            int Skip = (request.Page - 1) * request.Limit;

            BasePagingResponse PageInfo = new()
            {
                TotalData = TotalUser,
                TotalPage = TotalPage,
                PageLimit = request.Limit,
                PageNum = request.Page,
                HasNext = request.Page >= TotalPage ? false : true,
                HasPrevious = request.Page == 1 ? false : true,
            };

            List<Category> CategoryList = Categories.Skip(Skip).Take(request.Limit).ToList();
            List<CategoryQueryDto> CategoryDtoList = CategoryList.Adapt<List<CategoryQueryDto>>();

            return new BaseResponseWithPaging<List<CategoryQueryDto>>(new BaseResponse<List<CategoryQueryDto>>(CategoryDtoList), PageInfo);
        }
    }
}
