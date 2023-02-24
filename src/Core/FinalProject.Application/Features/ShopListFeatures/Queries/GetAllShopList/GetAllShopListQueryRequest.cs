using FinalProject.Application.DTOs.ShopList;
using FinalProject.Application.Wrappers.Base;
using MediatR;

namespace FinalProject.Application.Features.ShopListFeatures.Queries.GetAllShopList
{
    public class GetAllShopListQueryRequest : ShopListGetAllRequestDto, IRequest<BaseResponseWithPaging<List<ShopListQueryDto>>>
    {

    }
}
