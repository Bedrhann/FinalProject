using FinalProject.Application.DTOs.Category;
using FinalProject.Application.Interfaces.Services.CategoryService;
using FinalProject.Application.Wrappers.Base;
using MediatR;

namespace FinalProject.Application.Features.CategoryFeatures.Queries.GetCategoryById
{
    public class GetCategoryByIdQueryHandler : IRequestHandler<GetCategoryByIdQueryRequest, BaseResponse<CategoryQueryDto>>
    {
        private readonly ICategoryQueryService _service;

        public GetCategoryByIdQueryHandler(ICategoryQueryService service)
        {
            _service = service;
        }

        public async Task<BaseResponse<CategoryQueryDto>> Handle(GetCategoryByIdQueryRequest request, CancellationToken cancellationToken)
        {

            return await _service.GetByIdAsync(request.Id);
        }
    }
}
