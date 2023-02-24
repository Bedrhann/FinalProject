using FinalProject.Application.DTOs.ShopList;
using FinalProject.Application.Wrappers.Base;
using MediatR;

namespace FinalProject.Application.Features.ShopListFeatures.Queries.GetAllArchiveShopList
{
    public class GetAllArchiveShopListQueryRequest : ShopListGetAllRequestDto, IRequest<BaseResponseWithPaging<List<ShopListQueryDto>>>
    {

    }
}
