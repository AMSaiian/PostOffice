using BusinessLogic.Models;
using FluentValidation;

namespace BusinessLogic.Validation
{
    public class PostOfficeValidator : AbstractValidator<PostOfficeModel>
    {
        public PostOfficeValidator()
        {
            RuleFor(po => po.Zip).Cascade(CascadeMode.Stop)
                .NotNull().WithMessage("Zip must be defined")
                .NotEmpty().WithMessage("Zip must be defined")
                .Length(5).WithMessage("Zip must contain 5 numbers")
                .Matches("^[0-9]*$").WithMessage("Zip must contain only numbers");

            RuleFor(po => po.Location).SetValidator(new AddressModelValidator());
        }
    }
}
