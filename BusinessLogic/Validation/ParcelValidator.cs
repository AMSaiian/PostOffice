using BusinessLogic.Models;
using FluentValidation;

namespace BusinessLogic.Validation
{
    public class ParcelValidator : AbstractValidator<ParcelModel>
    {
        public ParcelValidator()
        {
            RuleFor(p => p.Status).Cascade(CascadeMode.Stop)
                .NotNull().WithMessage("Parcel status must be defined")
                .IsInEnum().WithMessage("Parcel status must be defined correctly");
        }
    }
}
