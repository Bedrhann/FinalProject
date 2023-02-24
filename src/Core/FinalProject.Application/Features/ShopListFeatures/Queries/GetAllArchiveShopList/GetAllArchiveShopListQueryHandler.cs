using FinalProject.Application.DTOs.ShopList;
using FinalProject.Application.Features.ShopListFeatures.Queries.GetAllShopList;
using FinalProject.Application.Interfaces.Services.ShopListService;
using FinalProject.Application.Wrappers.Base;
using Mapster;
using MediatR;

namespace FinalProject.Application.Features.ShopListFeatures.Queries.GetAllArchiveShopList
{
    public class GetAllArchiveShopListQueryHandler : IRequestHandler<GetAllArchiveShopListQueryRequest, BaseResponseWithPaging<List<ShopListQueryDto>>>
    {
        private readonly IShopListQueryService _service;

        public GetAllArchiveShopListQueryHandler(IShopListQueryService service)
        {
            _service = service;
        }

        public async Task<BaseResponseWithPaging<List<ShopListQueryDto>>> Handle(GetAllArchiveShopListQueryRequest request, CancellationToken cancellationToken)
        {
            return await _service.GetAllAsync(request, false, true);
        }
    }
}
