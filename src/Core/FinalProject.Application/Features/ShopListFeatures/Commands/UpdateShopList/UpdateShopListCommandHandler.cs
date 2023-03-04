using FinalProject.Application.DTOs.ShopList;
using FinalProject.Application.Interfaces.Services.ShopListService;
using FinalProject.Application.Wrappers.Base;
using MediatR;

namespace FinalProject.Application.Features.ShopListFeatures.Commands.UpdateShopList
{
    public class UpdateShopListCommandHandler : IRequestHandler<UpdateShopListCommandRequest, BaseResponse<ShopListUpdateDto>>
    {
        private readonly IShopListCommandService _service;

        public UpdateShopListCommandHandler(IShopListCommandService service)
        {
            _service = service;
        }

        public async Task<BaseResponse<ShopListUpdateDto>> Handle(UpdateShopListCommandRequest request, CancellationToken cancellationToken)
        {
            return await _service.UpdateAsync(request.Id, request);
        }
    }
}
