using FinalProject.Application.DTOs.Category;
using FinalProject.Application.Wrappers.Base;
using MediatR;

namespace FinalProject.Application.Features.CategoryFeatures.Commands.CreateCategory
{
    public class CreateCategoryCommandRequest : IRequest<BaseResponse<CategoryCreateDto>>
    {
        public Guid ShopListId { get; set; }
        public string Name { get; set; }
    }
}
