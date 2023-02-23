using FinalProject.Application.DTOs.ShopList;
using FinalProject.Application.Wrappers.Base;
using FinalProject.Application.Wrappers.Paging;
using MediatR;

namespace FinalProject.Application.Features.ShopListFeatures.Queries.GetAllShopList
{
    public class GetAllShopListQueryRequest : BasePagingRequest, IRequest<BaseResponseWithPaging<List<ShopListQueryDto>>>
    {
        public Guid? UserId { get; set; }
        public string? SearchByName { get; set; }
        public DateTime? CreationRangeCeiling { get; set; }
        public DateTime? CreationRangeLower { get; set; }
        public DateTime? UpdateRangeCeiling { get; set; }
        public DateTime? UpdateRangeLower { get; set; }
        public bool IsCompleted { get; set; }
    }
}
