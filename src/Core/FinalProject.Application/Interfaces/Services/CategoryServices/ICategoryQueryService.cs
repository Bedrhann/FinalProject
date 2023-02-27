using FinalProject.Application.DTOs.Category;
using FinalProject.Application.Features.CategoryFeatures.Queries.GetAllCategoryByShopList;
using FinalProject.Application.Wrappers.Base;
using FinalProject.Domain.Entities;

namespace FinalProject.Application.Interfaces.Services.CategoryService
{
    public interface ICategoryQueryService : IBaseQueryService<CategoryQueryDto, Category>
    {
        Task<BaseResponse<List<CategoryQueryDto>>> GetAllAsync(GetAllCategoryByShopListQueryRequest request);
    }
}
