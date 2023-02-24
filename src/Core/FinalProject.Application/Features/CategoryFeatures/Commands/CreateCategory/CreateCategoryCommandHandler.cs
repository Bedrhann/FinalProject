using FinalProject.Application.DTOs.Category;
using FinalProject.Application.Interfaces.Repositories.CategoryRepositories;
using FinalProject.Application.Interfaces.Services.CategoryService;
using FinalProject.Application.Wrappers.Base;
using FinalProject.Application.Wrappers.Responses;
using FinalProject.Domain.Entities;
using Mapster;
using MediatR;

namespace FinalProject.Application.Features.CategoryFeatures.Commands.CreateCategory
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommandRequest, BaseResponse<CategoryCommandDto>>
    {
        private readonly ICategoryCommandService _service;

        public CreateCategoryCommandHandler(ICategoryCommandService service)
        {
            _service = service;
        }

        public async Task<BaseResponse<CategoryCommandDto>> Handle(CreateCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            return _service.InsertAsync(,)



            //Category NewCategory = request.Adapt<Category>();
            //bool result = await _repository.AddAsync(NewCategory);
            //await _repository.SaveAsync();
            //CreateCategoryCommandResponse response = new();

            //if (result)
            //{
            //    response.NewCategoryId = NewCategory.Id;
            //    response.Success = true;
            //    response.Message = "Category Added";
            //}
            //return response;
        }
    }
}
