using FinalProject.Application.DTOs.ShopList;
using FinalProject.Application.Wrappers.Base;
using MediatR;

namespace FinalProject.Application.Features.ShopListFeatures.Queries.GetShopListById
{
    public class GetShopListByIdQueryRequest : IRequest<BaseResponse<ShopListQueryDto>>
    {
        public Guid Id { get; set; }
    }
}
