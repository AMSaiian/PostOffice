using BusinessLogic.Models;
using FluentValidation;

namespace BusinessLogic.Validation
{
    public class ParcelStatusHistoryValidator : AbstractValidator<ParcelStatusHistoryModel>
    {
        public ParcelStatusHistoryValidator()
        {
            RuleFor(psh => psh.Status).Cascade(CascadeMode.Stop)
                .NotNull().WithMessage("Status must be defined")
                .IsInEnum().WithMessage("Status must be defined correctly");

            RuleFor(psh => psh.ChangesTime).Cascade(CascadeMode.Stop)
                .NotNull().WithMessage("Changes time must be defined")
                .LessThanOrEqualTo(DateTime.Now).WithMessage("Changes time must be in past");

            RuleFor(psh => psh.ParcelId).Cascade(CascadeMode.Stop)
                .NotNull().WithMessage("Parcel must be defined")
                .NotEmpty().WithMessage("Parcel must be defined");
        }
    }
}
