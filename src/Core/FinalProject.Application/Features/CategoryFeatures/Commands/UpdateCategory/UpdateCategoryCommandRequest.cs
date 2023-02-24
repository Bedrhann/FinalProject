using FinalProject.Application.DTOs.Category;
using FinalProject.Application.Wrappers.Base;
using MediatR;

namespace FinalProject.Application.Features.CategoryFeatures.Commands.UpdateCategory
{
    public class UpdateCategoryCommandRequest : IRequest<BaseResponse<CategoryCommandDto>>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
