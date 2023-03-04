using FinalProject.Application.DTOs.ShopList;
using FinalProject.Application.Wrappers.Base;
using MediatR;

namespace FinalProject.Application.Features.ShopListFeatures.Commands.UpdateShopList
{
    public class UpdateShopListCommandRequest : ShopListUpdateDto, IRequest<BaseResponse<ShopListUpdateDto>>
    {
       
    }
}
