using FinalProject.Application.Features.ProductFeatures.Commands.UpdateProduct;
using FluentValidation;

namespace FinalProject.Application.Validators.ProductValidators
{
    public class UpdateProductValidator : AbstractValidator<UpdateProductCommandRequest>
    {
        public UpdateProductValidator()
        {
            RuleFor(c => c.Id)
            .NotNull().NotEmpty()
            .WithMessage("Please specify a valid Id for Product!");
            
            RuleFor(c => c.Name)
            .NotNull().NotEmpty()
            .WithMessage("Please specify a Name!");

            RuleFor(c => c.Quantity)
            .NotNull().NotEmpty()
            .WithMessage("Please specify a Quantity!")
            .Must(x => x >= 0).WithMessage("Quantity cannot be less than zero");
        }
    }
}
