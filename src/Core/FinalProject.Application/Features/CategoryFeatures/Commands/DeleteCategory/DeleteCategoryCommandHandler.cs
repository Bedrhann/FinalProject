using FinalProject.Application.DTOs.Category;
using FinalProject.Application.Interfaces.Services.CategoryService;
using FinalProject.Application.Wrappers.Base;
using MediatR;

namespace FinalProject.Application.Features.CategoryFeatures.Commands.DeleteCategory
{

    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommandRequest, BaseResponse<CategoryCommandDto>>
    {
        private readonly ICategoryCommandService _service;

        public DeleteCategoryCommandHandler(ICategoryCommandService service)
        {
            _service = service;
        }

        public async Task<BaseResponse<CategoryCommandDto>> Handle(DeleteCategoryCommandRequest request, CancellationToken cancellationToken)
        {

            return await _service.RemoveAsync(request.Id);
        }
    }
}
