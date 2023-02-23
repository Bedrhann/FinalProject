using FinalProject.Application.DTOs.ShopList;
using FinalProject.Application.Interfaces.Services.ShopListService;
using FinalProject.Application.Wrappers.Base;
using MediatR;

namespace FinalProject.Application.Features.ShopListFeatures.Commands.DeleteShopList
{
    public class DeleteShopListCommandHandler : IRequestHandler<DeleteShopListCommandRequest, BaseResponse<ShopListCommandDto>>
    {
        private readonly IShopListCommandService _service;

        public DeleteShopListCommandHandler(IShopListCommandService service)
        {
            _service = service;
        }

        public async Task<BaseResponse<ShopListCommandDto>> Handle(DeleteShopListCommandRequest request, CancellationToken cancellationToken)
        {
            return await _service.SoftRemoveAsync(request.Id);
        }

    }
}
