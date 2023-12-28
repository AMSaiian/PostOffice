using BusinessLogic.Models;
using FluentValidation;

namespace BusinessLogic.Validation
{
    public class ItemCategoryValidator : AbstractValidator<ItemCategoryModel>
    {
        public ItemCategoryValidator()
        {
            RuleFor(ic => ic.Name).NotNull().NotEmpty().Matches(@"^[A-Za-z.,'\s\-]+$");
        }
    }
}
