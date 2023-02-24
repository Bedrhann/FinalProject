using FinalProject.Application.DTOs.Product;
using FinalProject.Application.Wrappers.Base;
using FinalProject.Domain.Entities.Enums;
using MediatR;

namespace FinalProject.Application.Features.ProductFeatures.Commands.UpdateProduct
{
    public class UpdateProductCommandRequest : IRequest<BaseResponse<ProductCommandDto>>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public float Quantity { get; set; }
        public MeasurementType MeasurementType { get; set; }
        public bool IsPurchased { get; set; }
    }
}
