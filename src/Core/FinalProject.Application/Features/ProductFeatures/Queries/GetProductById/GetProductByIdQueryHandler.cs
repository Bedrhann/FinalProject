using FinalProject.Application.DTOs.Product;
using FinalProject.Application.Interfaces.Services.ProductService;
using FinalProject.Application.Wrappers.Base;
using MediatR;

namespace FinalProject.Application.Features.ProductFeatures.Queries.GetProductById
{
    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQueryRequest, BaseResponse<ProductQueryDto>>
    {
        private readonly IProductQueryService _service;

        public GetProductByIdQueryHandler(IProductQueryService service)
        {
            _service = service;
        }

        public async Task<BaseResponse<ProductQueryDto>> Handle(GetProductByIdQueryRequest request, CancellationToken cancellationToken)
        {

            return await _service.GetByIdAsync(request.Id);
        }
    }
}
