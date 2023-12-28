using BusinessLogic.Models;
using FluentValidation;

namespace BusinessLogic.Validation
{
    public class ParcelStatusHistoryValidator : AbstractValidator<ParcelStatusHistoryModel>
    {
        public ParcelStatusHistoryValidator()
        {
            RuleFor(psh => psh.Status).NotNull().IsInEnum();

            RuleFor(psh => psh.ChangesTime).NotNull().LessThanOrEqualTo(DateTime.Now);

            RuleFor(psh => psh.ParcelId).NotNull().NotEmpty();
        }
    }
}
