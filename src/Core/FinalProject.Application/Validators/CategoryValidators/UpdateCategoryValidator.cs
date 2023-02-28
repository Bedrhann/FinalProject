using FinalProject.Application.Features.CategoryFeatures.Commands.UpdateCategory;
using FluentValidation;

namespace FinalProject.Application.Validators.CategoryValidators
{
    public class UpdateCategoryValidator : AbstractValidator<UpdateCategoryCommandRequest>
    {
        public UpdateCategoryValidator()
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
