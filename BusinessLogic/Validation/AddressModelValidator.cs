using BusinessLogic.Models;
using FluentValidation;

namespace BusinessLogic.Validation
{
    public class AddressModelValidator : AbstractValidator<PostOfficeModel.AddressModel>
    {
        public AddressModelValidator()
        {
            RuleFor(a => a.City).Cascade(CascadeMode.Stop)
                .NotNull().WithMessage("City must be defined")
                .NotEmpty().WithMessage("City must be defined")
                .Matches(@"^[A-Z][a-z]+(?:[-\s][A-Z][a-z]+)?$").WithMessage("City format is invalid");

            RuleFor(a => a.Street).Cascade(CascadeMode.Stop)
                .NotNull().WithMessage("Street must be defined")
                .NotEmpty().WithMessage("Street must be defined")
                .Matches(@"^[A-Z][a-zA-Z ,.\-']+$").WithMessage("Street format is invalid");

            RuleFor(a => a.BuildingNumber).Cascade(CascadeMode.Stop)
                .NotNull().WithMessage("Building number must be defined")
                .NotEmpty().WithMessage("Building number must be defined")
                .Matches(@"^[0-9A-Za-z\-\/]*$").WithMessage("Building format is invalid");
        }
    }
}
