using FinalProject.Application.DTOs.Product;
using FinalProject.Application.Wrappers.Base;
using MediatR;

namespace FinalProject.Application.Features.ProductFeatures.Queries.GetProductById
{
    public class GetProductByIdQueryRequest : IRequest<BaseResponse<ProductQueryDto>>
    {
        public Guid Id { get; set; }
    }
}
