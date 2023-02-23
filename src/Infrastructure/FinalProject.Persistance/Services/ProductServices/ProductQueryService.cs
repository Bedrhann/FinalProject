using FinalProject.Application.DTOs.Base;
using FinalProject.Application.Features.UserFeatures.Commands.CreateUser;
using FinalProject.Application.Interfaces.Repositories.ProductRepositories;
using FinalProject.Application.Wrappers.Base;
using FinalProject.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;

namespace FinalProject.Persistance.Services.ProductServices
{
    public class ProductQueryService
    {
        private readonly IProductCommandRepository _repositoryCommand;
        private readonly IProductQueryRepository _repositoryQuery;
        public ProductQueryService(IProductCommandRepository repositoryCommand, IProductQueryRepository repositoryQuery)
        {
            _repositoryCommand = repositoryCommand;
            _repositoryQuery = repositoryQuery;
        }


    }
}
