using FinalProject.Application.DTOs.Product;
using FinalProject.Application.Interfaces.Repositories.Common;
using FinalProject.Application.Interfaces.Services.ProductService;
using FinalProject.Domain.Entities;
using FinalProject.Persistance.Services.BaseServices;

namespace FinalProject.Persistance.Services.ProductServices
{
    public class ProductCommandService : BaseCommandService<ProductCreateDto,ProductUpdateDto, Product>, IProductCommandService
    {
        private readonly IBaseCommandRepository<Product> _repositoryCommand;
        private readonly IBaseQueryRepository<Product> _repositoryQuery;

        public ProductCommandService(IBaseQueryRepository<Product> repositoryQuery, IBaseCommandRepository<Product> repositoryCommand) : base(repositoryCommand, repositoryQuery)
        {
            this._repositoryQuery = repositoryQuery;
            this._repositoryCommand = repositoryCommand;
        }
    }
}
