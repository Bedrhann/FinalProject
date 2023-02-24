using FinalProject.Application.Interfaces.Repositories.ProductRepositories;
using FinalProject.Application.Models.Paging;
using FinalProject.Application.DTOs.Product;
using FinalProject.Domain.Entities;
using Mapster;
using MediatR;
using FinalProject.Application.Wrappers.Base;
using FinalProject.Application.Interfaces.Services.ProductService;

namespace FinalProject.Application.Features.ProductFeatures.Queries.GetAllProductByCategory
{
    public class GetAllProductByCategoryQueryHandler : IRequestHandler<GetAllProductByCategoryQueryRequest, BaseResponseWithPaging<List<ProductQueryDto>>>
    {
        private readonly IProductQueryService _service;

        public GetAllProductByCategoryQueryHandler(IProductQueryService service)
        {
            _service = service;
        }

        public async Task<BaseResponseWithPaging<List<ProductQueryDto>>> Handle(GetAllProductByCategoryQueryRequest request, CancellationToken cancellationToken)
        {

            return await _service.GetAllAsync(request);
        }
    }
}
