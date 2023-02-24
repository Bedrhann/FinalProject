using FinalProject.Application.DTOs.ShopList;
using FinalProject.Application.Wrappers.Base;
using MediatR;

namespace FinalProject.Application.Features.ShopListFeatures.Queries.GetAllShopListByUser
{
    public class GetAllShopListByUserQueryRequest : ShopListGetAllRequestDto, IRequest<BaseResponseWithPaging<List<ShopListQueryDto>>>
    {

    }
}
