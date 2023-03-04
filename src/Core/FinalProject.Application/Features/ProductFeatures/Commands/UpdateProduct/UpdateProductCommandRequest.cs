using FinalProject.Application.DTOs.Product;
using FinalProject.Application.Wrappers.Base;
using MediatR;

namespace FinalProject.Application.Features.ProductFeatures.Commands.UpdateProduct
{
    public class UpdateProductCommandRequest : ProductUpdateDto, IRequest<BaseResponse<ProductUpdateDto>>
    {

    }
}
