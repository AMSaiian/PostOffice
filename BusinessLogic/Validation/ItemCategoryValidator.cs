using BusinessLogic.Models;
using FluentValidation;

namespace BusinessLogic.Validation
{
    public class ItemCategoryValidator : AbstractValidator<ItemCategoryModel>
    {
        public ItemCategoryValidator()
        {
            RuleFor(ic => ic.Name).Cascade(CascadeMode.Stop)
                .NotNull().WithMessage("Category name must be defined")
                .NotEmpty().WithMessage("Category name must be defined")
                .Matches(@"^[A-Za-z.,'\s\-]+$").WithMessage("Category name must contain only letters, dots and comas");
        }
    }
}
