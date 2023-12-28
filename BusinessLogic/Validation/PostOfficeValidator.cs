using BusinessLogic.Models;
using FluentValidation;

namespace BusinessLogic.Validation
{
    public class PostOfficeValidator : AbstractValidator<PostOfficeModel>
    {
        public PostOfficeValidator()
        {
            RuleFor(po => po.Zip).NotNull().NotEmpty().Length(5).WithMessage("Zip length must be 5")
                .Matches("^[0-9]*$").WithMessage("Zip must contain only numbers");

            RuleFor(po => po.Location).SetValidator(new AddressModelValidator());
        }
    }
}
