using FinalProject.Application.DTOs.Category;
using FinalProject.Application.Interfaces.Services.CategoryService;
using FinalProject.Application.Wrappers.Base;
using MediatR;

namespace FinalProject.Application.Features.CategoryFeatures.Queries.GetAllCategoryByShopList
{
    public class GetAllCategoryByShopListQueryHandler : IRequestHandler<GetAllCategoryByShopListQueryRequest, BaseResponseWithPaging<List<CategoryQueryDto>>>
    {
        private readonly ICategoryQueryService _service;

        public GetAllCategoryByShopListQueryHandler(ICategoryQueryService service)
        {
            _service = service;
        }

        public async Task<BaseResponseWithPaging<List<CategoryQueryDto>>> Handle(GetAllCategoryByShopListQueryRequest request, CancellationToken cancellationToken)
        {

            return await _service.GetAllAsync(request);
        }
    }
}
