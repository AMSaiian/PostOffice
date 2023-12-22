using BusinessLogic.Models;
using FluentValidation;

namespace BusinessLogic.Validation
{
    public class AddressModelValidator : AbstractValidator<PostOfficeModel.AddressModel>
    {
        public AddressModelValidator()
        {
            RuleFor(a => a.City).NotNull().NotEmpty()
                .Matches(@"^[A-Z][a-z]+(?:[-\s][A-Z][a-z]+)?$");

            RuleFor(a => a.Street).NotNull().NotEmpty()
                .Matches(@"^[A-Z][a-zA-Z ,.\-']+$");

            RuleFor(a => a.BuildingNumber).NotNull().NotEmpty()
                .Matches(@"^[0-9A-Za-z\-\/]*$");
        }
    }
}
