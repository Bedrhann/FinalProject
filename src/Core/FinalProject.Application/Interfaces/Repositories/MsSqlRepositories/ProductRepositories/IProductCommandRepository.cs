﻿using FinalProject.Application.Interfaces.Repositories.Common;
using FinalProject.Domain.Entities;


namespace FinalProject.Application.Interfaces.Repositories.ProductRepositories
{
    public interface IProductCommandRepository : IBaseCommandRepository<Product>
    {
    }
}
