using FinalProject.Application.DTOs.Category;
using FinalProject.Domain.Entities;

namespace FinalProject.Application.Interfaces.Services.CategoryService
{
    public interface ICategoryQueryService : IBaseQueryService<CategoryQueryDto, Category>
    {
    }
}
