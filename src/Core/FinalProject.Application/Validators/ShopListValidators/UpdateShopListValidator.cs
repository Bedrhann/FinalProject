using FinalProject.Application.Features.ShopListFeatures.Commands.UpdateShopList;
using FluentValidation;

namespace FinalProject.Application.Validators.ShopListValidators
{
    public class UpdateShopListValidator : AbstractValidator<UpdateShopListCommandRequest>
    {
        public UpdateShopListValidator()
        {
            RuleFor(c => c.Id)
            .NotNull().NotEmpty()
            .WithMessage("Please specify a valid Id for User!");

            RuleFor(c => c.Name)
            .NotNull().NotEmpty()
            .WithMessage("Please specify a Name!");

            RuleFor(c => c.Description)
            .NotNull().NotEmpty()
            .WithMessage("Please specify a Description!");
        }
    }
}
