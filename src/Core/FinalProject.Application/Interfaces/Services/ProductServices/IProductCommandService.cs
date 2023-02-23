using FinalProject.Application.Features.ProductFeatures.Commands.CreateProduct;
using FinalProject.Domain.Entities;

namespace FinalProject.Application.Interfaces.Services.ProductService
{
    public interface IProductCommandService : IBaseCommandService<CreateProductCommandRequest, Product>
    {
    }
}
