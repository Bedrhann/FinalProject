using FinalProject.Application.Features.CategoryFeatures.Commands.CreateCategory;

namespace FinalProject.Application.Interfaces.Services.CategoryService
{
    public interface ICategoryCommandService : IBaseCommandService<CreateCategoryCommandRequest, FinalProject.Domain.Entities.Category>
    {
    }
}
