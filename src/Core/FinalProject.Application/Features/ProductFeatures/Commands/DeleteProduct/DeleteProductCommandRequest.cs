using FinalProject.Application.DTOs.Product;
using FinalProject.Application.Wrappers.Base;
using MediatR;

namespace FinalProject.Application.Features.ProductFeatures.Commands.DeleteProduct
{
    public class DeleteProductCommandRequest : IRequest<BaseResponse<ProductCommandDto>>
    {
        public Guid Id { get; set; }
    }
}
