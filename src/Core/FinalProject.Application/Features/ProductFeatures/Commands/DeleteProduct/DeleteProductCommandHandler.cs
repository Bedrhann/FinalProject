using FinalProject.Application.DTOs.Product;
using FinalProject.Application.Interfaces.Services.ProductService;
using FinalProject.Application.Wrappers.Base;
using MediatR;

namespace FinalProject.Application.Features.ProductFeatures.Commands.DeleteProduct
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommandRequest, BaseResponse<ProductCommandDto>>
    {
        private readonly IProductCommandService _service;

        public DeleteProductCommandHandler(IProductCommandService service)
        {
            _service = service;
        }
        public async Task<BaseResponse<ProductCommandDto>> Handle(DeleteProductCommandRequest request, CancellationToken cancellationToken)
        {

            return await _service.RemoveAsync(request.Id);
        }
    }
}
