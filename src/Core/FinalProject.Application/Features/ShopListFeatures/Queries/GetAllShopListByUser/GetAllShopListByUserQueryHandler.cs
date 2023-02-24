using FinalProject.Application.DTOs.ShopList;
using FinalProject.Application.Features.ShopListFeatures.Queries.GetAllShopList;
using FinalProject.Application.Interfaces.Services.ShopListService;
using FinalProject.Application.Wrappers.Base;
using Mapster;
using MediatR;

namespace FinalProject.Application.Features.ShopListFeatures.Queries.GetAllShopListByUser
{
    public class GetAllShopListByUserQueryHandler : IRequestHandler<GetAllShopListByUserQueryRequest, BaseResponseWithPaging<List<ShopListQueryDto>>>
    {
        private readonly IShopListQueryService _service;

        public GetAllShopListByUserQueryHandler(IShopListQueryService service)
        {
            _service = service;
        }

        public async Task<BaseResponseWithPaging<List<ShopListQueryDto>>> Handle(GetAllShopListByUserQueryRequest request, CancellationToken cancellationToken)
        {

            return await _service.GetAllAsync(request, true);
        }
    }
}
