using FinalProject.Application.DTOs.Category;
using FinalProject.Application.Models.Paging;

namespace FinalProject.Application.Features.CategoryFeatures.Queries.GetAllCategoryByShopList
{
    public class GetAllCategoryByShopListQueryResponse
    {
        public List<CategoryQueryDto> Categories { get; set; }
        public BasePagingResponse PagingInfo { get; set; }
    }
}
