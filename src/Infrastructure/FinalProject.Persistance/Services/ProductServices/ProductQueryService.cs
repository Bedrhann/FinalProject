using FinalProject.Application.DTOs.Product;
using FinalProject.Application.DTOs.ShopList;
using FinalProject.Application.Features.ProductFeatures.Queries.GetAllProductByCategory;
using FinalProject.Application.Interfaces.Repositories.Common;
using FinalProject.Application.Interfaces.Services.ProductService;
using FinalProject.Application.Wrappers.Base;
using FinalProject.Application.Wrappers.Paging;
using FinalProject.Domain.Entities;
using Mapster;

namespace FinalProject.Persistance.Services.ProductServices
{
    public class ProductQueryService : BaseQueryService<ProductQueryDto, Product>, IProductQueryService
    {
        private readonly IBaseQueryRepository<Product> _repositoryQuery;

        public ProductQueryService(IBaseQueryRepository<Product> repositoryQuery) : base(repositoryQuery)
        {
            this._repositoryQuery = repositoryQuery;
        }

        public async Task<BaseResponseWithPaging<List<ProductQueryDto>>> GetAllAsync(GetAllProductByCategoryQueryRequest request)
        {
            IQueryable<Product> Products = _repositoryQuery.GetWhere(x => x.CategoryId == request.CategoryId);

            if (!string.IsNullOrWhiteSpace(request.SearchByName))
            {
                Products = Products.Where(x => x.Name.Contains(request.SearchByName));
            }

            if (request.CreationRangeCeiling.HasValue || request.CreationRangeLower.HasValue)
            {
                Products = Products.Where(x => x.CreationDate <= request.CreationRangeCeiling && x.CreationDate >= request.CreationRangeLower);
            }

            if (request.UpdateRangeCeiling.HasValue || request.UpdateRangeLower.HasValue)
            {
                Products = Products.Where(x => x.UpdateDate <= request.UpdateRangeCeiling && x.UpdateDate >= request.CreationRangeLower);
            }

            int TotalUser = Products.Count();
            int TotalPage = (int)Math.Ceiling(TotalUser / (double)request.Limit);
            int Skip = (request.Page - 1) * request.Limit;

            BasePagingResponse PageInfo = new()
            {
                TotalData = TotalUser,
                TotalPage = TotalPage,
                PageLimit = request.Limit,
                PageNum = request.Page,
                HasNext = request.Page >= TotalPage ? false : true,
                HasPrevious = request.Page == 1 ? false : true,
            };

            List<Product> ProductList = Products.Skip(Skip).Take(request.Limit).ToList();
            List<ProductQueryDto> ProductDtoList = ProductList.Adapt<List<ProductQueryDto>>();

            return new BaseResponseWithPaging<List<ProductQueryDto>>(new BaseResponse<List<ProductQueryDto>>(ProductDtoList), PageInfo);
        }
    }
}
