using FinalProject.Application.DTOs.Category;
using FinalProject.Application.Interfaces.Repositories.Common;
using FinalProject.Application.Interfaces.Services.CategoryService;
using FinalProject.Domain.Entities;

namespace FinalProject.Persistance.Services.CategoryServices
{
    public class CategoryCommandService : BaseCommandService<CategoryCommandDto, Category>, ICategoryCommandService
    {
        private readonly IBaseCommandRepository<Category> _commandRepository;
        private readonly IBaseQueryRepository<Category> _queryRepository;

        public CategoryCommandService(IBaseCommandRepository<Category> commandRepository, IBaseQueryRepository<Category> queryRepository) : base(commandRepository,queryRepository)
        {
            _commandRepository = commandRepository;
            _queryRepository = queryRepository;
        }

    }
}
