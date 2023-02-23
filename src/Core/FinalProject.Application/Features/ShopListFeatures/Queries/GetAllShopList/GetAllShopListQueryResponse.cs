using FinalProject.Application.DTOs.ShopList;
using FinalProject.Application.Models.Paging;

namespace FinalProject.Application.Features.ShopListFeatures.Queries.GetAllShopList
{
    public class GetAllShopListQueryResponse
    {
        public List<ShopListQueryDto> Lists { get; set; }
        public BasePagingResponse PagingInfo { get; set; }
    }
}
