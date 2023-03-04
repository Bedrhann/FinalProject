using FinalProject.Application.DTOs.Category;
using FinalProject.Application.Wrappers.Base;
using MediatR;

namespace FinalProject.Application.Features.CategoryFeatures.Commands.DeleteCategory
{
    public class DeleteCategoryCommandRequest : IRequest<BaseResponse<object>>
    {
        public Guid Id { get; set; }
    }
}
