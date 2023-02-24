using FinalProject.Application.DTOs.Product;
using FinalProject.Application.Features.ProductFeatures.Queries.GetAllProductByCategory;
using FinalProject.Application.Wrappers.Base;
using FinalProject.Domain.Entities;

namespace FinalProject.Application.Interfaces.Services.ProductService
{
    public interface IProductQueryService : IBaseQueryService<ProductQueryDto, Product>
    {
        Task<BaseResponseWithPaging<List<ProductQueryDto>>> GetAllAsync(GetAllProductByCategoryQueryRequest request);
    }
}
