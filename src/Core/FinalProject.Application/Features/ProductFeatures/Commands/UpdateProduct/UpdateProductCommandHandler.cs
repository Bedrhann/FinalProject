using FinalProject.Application.DTOs.Product;
using FinalProject.Application.Interfaces.Services.ProductService;
using FinalProject.Application.Wrappers.Base;
using Mapster;
using MediatR;

namespace FinalProject.Application.Features.ProductFeatures.Commands.UpdateProduct
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommandRequest, BaseResponse<ProductUpdateDto>>
    {
        private readonly IProductCommandService _service;

        public UpdateProductCommandHandler(IProductCommandService service)
        {
            _service = service;
        }

        public async Task<BaseResponse<ProductUpdateDto>> Handle(UpdateProductCommandRequest request, CancellationToken cancellationToken)
        {

            return await _service.UpdateAsync(request.Id, request);
        }
    }
}
