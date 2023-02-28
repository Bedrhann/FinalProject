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
           .WithMessage("Category Name can not be null!");
            RuleFor(c => c.ShopListId)
            .NotNull().NotEmpty()
            .WithMessage("Please specify a valid Id for ShopList!");
        }
    }
}
