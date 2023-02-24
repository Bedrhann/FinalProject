using FinalProject.Application.DTOs.Category;
using FinalProject.Application.Wrappers.Base;
using FinalProject.Application.Wrappers.Paging;
using MediatR;

namespace FinalProject.Application.Features.CategoryFeatures.Queries.GetAllCategoryByShopList
{
    public class GetAllCategoryByShopListQueryRequest : BasePagingRequest, IRequest<BaseResponseWithPaging<List<CategoryQueryDto>>>
    {
        public Guid ShopListId { get; set; }
        public string? SearchByName { get; set; }
        public DateTime? CreationRangeCeiling { get; set; }
        public DateTime? CreationRangeLower { get; set; }
        public DateTime? UpdateRangeCeiling { get; set; }
        public DateTime? UpdateRangeLower { get; set; }
    }
}
