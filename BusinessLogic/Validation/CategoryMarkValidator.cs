using BusinessLogic.Models;
using FluentValidation;

namespace BusinessLogic.Validation
{
    public class CategoryMarkValidator : AbstractValidator<CategoryMarkModel>
    {
        public CategoryMarkValidator()
        {
            RuleFor(cm => cm.CategoryId).NotNull().NotEmpty();

            RuleFor(cm => cm.MarkId).NotNull().NotEmpty();
        }
    }
}
