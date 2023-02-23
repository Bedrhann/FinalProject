using FinalProject.Application.Wrappers.Responses;
using FinalProject.Application.DTOs.ShopList;
using FinalProject.Application.Models.Paging;


namespace FinalProject.Application.Features.ShopListFeatures.Queries.GetAllShopListByUser
{
    public class GetAllShopListByUserQueryResponse : BaseResponse
    {
        public List<ShopListQueryDto> Lists { get; set; }
        public BasePagingResponse PagingInfo { get; set; }
    }
}
