using BusinessLogic.Models;
using FluentValidation;

namespace BusinessLogic.Validation
{
    public class ParcelItemValidator : AbstractValidator<ParcelItemModel>
    {
        public ParcelItemValidator()
        {
            RuleFor(pi => pi.Description).Cascade(CascadeMode.Stop)
                .NotNull().WithMessage("Parcel description must be defined")
                .NotEmpty().WithMessage("Parcel description must be defined")
                .Matches(@"^[A-Za-z.,'""\s\-]+$").WithMessage("Parcel description must be text");

            RuleFor(pi => pi.Characteristics).Cascade(CascadeMode.Stop)
                .NotNull().WithMessage("Item characteristics must be defined")
                .SetValidator(new GabaritesModelValidation());

            RuleFor(pi => pi.ItemCategoryId).Cascade(CascadeMode.Stop)
                .NotNull().WithMessage("Item category must be defined");
        }
    }
}
