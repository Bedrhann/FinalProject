using FinalProject.Application.DTOs.ShopList;
using FinalProject.Application.Interfaces.Services.ShopListService;
using FinalProject.Application.Wrappers.Base;
using MediatR;

namespace FinalProject.Application.Features.ShopListFeatures.Queries.GetShopListById
{
    public class GetShopListByIdQueryHandler : IRequestHandler<GetShopListByIdQueryRequest, BaseResponse<ShopListQueryDto>>
    {
        private readonly IShopListQueryService _service;

        public GetShopListByIdQueryHandler(IShopListQueryService service)
        {
            _service = service;
        }

        public async Task<BaseResponse<ShopListQueryDto>> Handle(GetShopListByIdQueryRequest request, CancellationToken cancellationToken)
        {
            return await _service.GetByIdAsync(request.Id);
        }
    }
}
