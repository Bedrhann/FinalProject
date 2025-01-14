﻿using FinalProject.Application.DTOs.Category;

namespace FinalProject.Application.Interfaces.Services.CategoryService
{
    public interface ICategoryCommandService : IBaseCommandService<CategoryCreateDto,CategoryUpdateDto, FinalProject.Domain.Entities.Category>
    {
    }
}
