using FinalProject.Application.Features.ProductFeatures.Commands.CreateProduct;
using FluentValidation;

namespace FinalProject.Application.Validators.ProductValidators
{
    public class CreateProductValidator : AbstractValidator<CreateProductCommandRequest>
    {
        public CreateProductValidator()
        {
            RuleFor(c => c.CategoryId)
            .NotNull().NotEmpty()
            .WithMessage("Please specify a valid Id for Category!");

            RuleFor(c => c.Name)
            .NotNull().NotEmpty()
            .WithMessage("Please specify a Name!");

            RuleFor(c => c.Quantity)
            .NotNull().NotEmpty()
            .WithMessage("Please specify a Quantity!")
            .LessThan(0).WithMessage("Quantity cannot be less than zero");
        }
    }
}
