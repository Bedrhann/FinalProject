using FinalProject.Application.DTOs.Category;
using FinalProject.Application.Wrappers.Base;
using MediatR;

namespace FinalProject.Application.Features.CategoryFeatures.Commands.UpdateCategory
{
    public class UpdateCategoryCommandRequest : CategoryUpdateDto, IRequest<BaseResponse<CategoryUpdateDto>>
    {
    }
}
