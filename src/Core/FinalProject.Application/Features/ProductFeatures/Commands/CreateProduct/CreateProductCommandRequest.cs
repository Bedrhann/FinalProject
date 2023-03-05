using FinalProject.Application.DTOs.Product;
using FinalProject.Application.Wrappers.Base;
using FinalProject.Domain.Entities.Enums;
using MediatR;


namespace FinalProject.Application.Features.ProductFeatures.Commands.CreateProduct
{
    public class CreateProductCommandRequest : IRequest<BaseResponse<ProductCreateDto>>
    {
        public string Name { get; set; }
        public float Quantity { get; set; }
        public MeasurementType MeasurementType { get; set; }
        public Guid CategoryId { get; set; }
    }
}
