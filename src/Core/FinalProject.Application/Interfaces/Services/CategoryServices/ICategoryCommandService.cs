using FinalProject.Application.DTOs.Category;

namespace FinalProject.Application.Interfaces.Services.CategoryService
{
    public interface ICategoryCommandService : IBaseCommandService<CategoryCommandDto, FinalProject.Domain.Entities.Category>
    {
    }
}
