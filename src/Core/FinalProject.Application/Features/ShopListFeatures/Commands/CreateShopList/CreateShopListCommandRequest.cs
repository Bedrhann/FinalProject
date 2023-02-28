using FinalProject.Application.DTOs.ShopList;
using FinalProject.Application.Wrappers.Base;
using MediatR;


namespace FinalProject.Application.Features.ShopListFeatures.Commands.CreateShopList
{
    public class CreateShopListCommandRequest : IRequest<BaseResponse<ShopListCommandDto>>
    {
        public Guid AppUserId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
