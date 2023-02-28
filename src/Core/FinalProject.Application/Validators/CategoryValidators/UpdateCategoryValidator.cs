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
            .WithMessage("BOŞ OLMASIN ADI ONA GÖRE");
            RuleFor(c => c.Id)
            .NotNull().NotEmpty()
            .WithMessage("BOŞ OLMASIN ID ONA GÖRE");
        }
    }
}
