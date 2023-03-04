using FinalProject.Application.DTOs.Category;
using FinalProject.Application.Interfaces.Repositories.CategoryRepositories;
using FinalProject.Application.Interfaces.Services.CategoryService;
using FinalProject.Application.Wrappers.Base;
using FinalProject.Domain.Entities;
using Mapster;
using MediatR;

namespace FinalProject.Application.Features.CategoryFeatures.Commands.UpdateCategory
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommandRequest, BaseResponse<CategoryUpdateDto>>
    {
        private readonly ICategoryCommandService _service;

        public UpdateCategoryCommandHandler(ICategoryCommandService service)
        {
            _service = service;
        }

        public async Task<BaseResponse<CategoryUpdateDto>> Handle(UpdateCategoryCommandRequest request, CancellationToken cancellationToken)
        {

            return await _service.UpdateAsync(request.Id, request);
        }
    }
}
