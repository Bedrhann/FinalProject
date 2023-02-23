using FinalProject.Application.DTOs.ShopList;
using FinalProject.Application.Interfaces.Services.ShopListService;
using FinalProject.Application.Wrappers.Base;
using Mapster;
using MediatR;

namespace FinalProject.Application.Features.ShopListFeatures.Commands.CreateShopList
{
    public class CreateShopListCommandHandler : IRequestHandler<CreateShopListCommandRequest, BaseResponse<ShopListCommandDto>>
    {
        private readonly IShopListCommandService _service;

        public CreateShopListCommandHandler(IShopListCommandService service)
        {
            _service = service;
        }

        public async Task<BaseResponse<ShopListCommandDto>> Handle(CreateShopListCommandRequest request, CancellationToken cancellationToken)
        {

            return await _service.InsertAsync(request.Adapt<ShopListCommandDto>());
        }
    }
}
