using BusinessLogic.Models;
using FluentValidation;

namespace BusinessLogic.Validation
{
    public class ParcelValidator : AbstractValidator<ParcelModel>
    {
        public ParcelValidator()
        {
            RuleFor(p => p.Status).NotNull().IsInEnum();
        }
    }
}
