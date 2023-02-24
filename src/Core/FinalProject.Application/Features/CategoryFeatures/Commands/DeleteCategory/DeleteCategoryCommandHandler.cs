using FinalProject.Application.DTOs.Category;
using FinalProject.Application.Interfaces.Repositories.CategoryRepositories;
using FinalProject.Application.Wrappers.Base;
using FinalProject.Application.Wrappers.Responses;
using FinalProject.Domain.Entities;
using MediatR;

namespace FinalProject.Application.Features.CategoryFeatures.Commands.DeleteCategory
{

    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommandRequest, BaseResponse<CategoryCommandDto>>
    {
        private readonly ICategoryQueryRepository _queryRepository;
        private readonly ICategoryCommandRepository _commandRepository;

        public DeleteCategoryCommandHandler(ICategoryCommandRepository commandRepository, ICategoryQueryRepository queryRepository)
        {
            _commandRepository = commandRepository;
            _queryRepository = queryRepository;
        }

        public async Task<BaseResponse<CategoryCommandDto>> Handle(DeleteCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            Category DeletedCategory = await _queryRepository.GetByIdAsync(request.Id.ToString());

            _commandRepository.Remove(DeletedCategory);
            _commandRepository.SaveAsync();

            BaseResponse response = new()
            {
                Success = true,
                Message = "Category Deleted"
            };
            return response;
            throw new NotImplementedException();
        }
    }
}
