using FinalProject.Application.DTOs.Product;
using FinalProject.Domain.Entities;

namespace FinalProject.Application.Interfaces.Services.ProductService
{
    public interface IProductCommandService : IBaseCommandService<ProductCommandDto, Product>
    {
    }
}
