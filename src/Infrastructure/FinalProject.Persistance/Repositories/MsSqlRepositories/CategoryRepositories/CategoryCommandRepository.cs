﻿using FinalProject.Application.Interfaces.Repositories.CategoryRepositories;
using FinalProject.Domain.Entities;
using FinalProject.Persistence.Contexts;
using FinalProject.Persistence.Repositories.Common;


namespace FinalProject.Persistence.Repositories.CategoryRepositories
{
    public class CategoryCommandRepository : BaseCommandRepository<Category>, ICategoryCommandRepository
    {
        public CategoryCommandRepository(MsSqlDbContext context) : base(context)
        {
        }
    }
}
