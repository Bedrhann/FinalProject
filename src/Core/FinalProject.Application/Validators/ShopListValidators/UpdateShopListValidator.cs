using FinalProject.Application.Features.ShopListFeatures.Commands.UpdateShopList;
using FluentValidation;

namespace FinalProject.Application.Validators.ShopListValidators
{
    public class UpdateShopListValidator : AbstractValidator<UpdateShopListCommandRequest>
    {
        public UpdateShopListValidator()
        {
            RuleFor(c => c.Name)
            .NotNull().NotEmpty()
            .WithMessage("Category Name can not be null!");
            RuleFor(c => c.Id)
            .NotNull().NotEmpty()
            .WithMessage("Please specify a valid Id for Category!");
        }
    }
}
