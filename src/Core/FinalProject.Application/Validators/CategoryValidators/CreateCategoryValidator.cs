using FinalProject.Application.Features.CategoryFeatures.Commands.CreateCategory;
using FluentValidation;

namespace FinalProject.Application.Validators.CategoryValidators
{
    public class CreateCategoryValidator : AbstractValidator<CreateCategoryCommandRequest>
    {
        public CreateCategoryValidator()
        {
            RuleFor(c => c.Name)
            .NotNull().NotEmpty()
            .WithMessage("BOŞ OLMASIN ADI ONA GÖRE");
            RuleFor(c => c.ShopListId)
            .NotNull().NotEmpty()
            .WithMessage("BOŞ OLMASIN ID ONA GÖRE");
        }
    }
}
