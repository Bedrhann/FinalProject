﻿using FinalProject.Application.DTOs.Category;
using FinalProject.Application.Interfaces.Services.CategoryService;
using FinalProject.Application.Wrappers.Base;
using Mapster;
using MediatR;

namespace FinalProject.Application.Features.CategoryFeatures.Commands.CreateCategory
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommandRequest, BaseResponse<CategoryCreateDto>>
    {
        private readonly ICategoryCommandService _service;

        public CreateCategoryCommandHandler(ICategoryCommandService service)
        {
            _service = service;
        }

        public async Task<BaseResponse<CategoryCreateDto>> Handle(CreateCategoryCommandRequest request, CancellationToken cancellationToken)
        {

            return await _service.InsertAsync(request.Adapt<CategoryCreateDto>());
        }
    }
}
