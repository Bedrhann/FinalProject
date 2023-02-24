using FinalProject.Application.DTOs.Category;
using FinalProject.Application.Interfaces.Services.CategoryService;
using FinalProject.Domain.Entities;
using FinalProject.Persistence.Repositories.Common;

namespace FinalProject.Persistance.Services.CategoryServices
{
    public class CategoryCommandService : BaseCommandService<CategoryCommandDto,Category> , ICategoryCommandService
    {
        private readonly BaseCommandRepository
    }
}
