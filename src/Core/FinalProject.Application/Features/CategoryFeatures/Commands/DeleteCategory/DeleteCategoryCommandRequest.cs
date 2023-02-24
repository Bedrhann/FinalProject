using FinalProject.Application.DTOs.Category;
using FinalProject.Application.Wrappers.Base;
using MediatR;

namespace FinalProject.Application.Features.CategoryFeatures.Commands.DeleteCategory
{
    public class DeleteCategoryCommandRequest : IRequest<BaseResponse<CategoryCommandDto>>
    {
        public Guid Id { get; set; }
    }
}
