using FinalProject.Application.DTOs.ShopList;
using FinalProject.Application.Interfaces.Services.ShopListService;
using FinalProject.Application.Wrappers.Base;
using FinalProject.Application.Wrappers.Paging;
using FinalProject.Domain.Entities;
using Mapster;
using MediatR;

namespace FinalProject.Application.Features.ShopListFeatures.Queries.GetAllShopList
{
    public class GetAllShopListQueryHandler : IRequestHandler<GetAllShopListQueryRequest, BaseResponseWithPaging<List<ShopListQueryDto>>>
    {
        private readonly IShopListQueryService _service;

        public GetAllShopListQueryHandler(IShopListQueryService service)
        {
            _service = service;
        }

        public async Task<BaseResponseWithPaging<List<ShopListQueryDto>>> Handle(GetAllShopListQueryRequest request, CancellationToken cancellationToken)
        {
            return await _service.GetAllAsync(request);
            
        }
    }
}
