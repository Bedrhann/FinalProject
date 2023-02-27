using FinalProject.Application.DTOs.Category;
using FinalProject.Application.Wrappers.Base;
using MediatR;

namespace FinalProject.Application.Features.CategoryFeatures.Queries.GetAllCategoryByShopList
{
    public class GetAllCategoryByShopListQueryRequest : IRequest<BaseResponse<List<CategoryQueryDto>>>
    {
        public Guid ShopListId { get; set; }
    }
}
