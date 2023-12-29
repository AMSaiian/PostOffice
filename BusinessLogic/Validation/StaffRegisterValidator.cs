using BusinessLogic.Models;
using FluentValidation;

namespace BusinessLogic.Validation
{
    public class StaffRegisterValidator : AbstractValidator<StaffRegisterModel>
    {
        public StaffRegisterValidator()
        {
            RuleFor(s => s.Name).NotNull().NotEmpty().Matches(@"^[A-Za-z.,'\s\-]+$");

            RuleFor(s => s.Surname).NotNull().NotEmpty().Matches(@"^[A-Za-z.,'\s\-]+$");

            RuleFor(s => s.PhoneNumber).NotNull().NotEmpty().Matches(@"^\+380\d{9}$");

            RuleFor(s => s.Password).NotNull().NotEmpty().MinimumLength(8);

            RuleFor(s => s.ConfirmPassword).Equal(s => s.Password);

            RuleFor(s => s.PostOfficeZip).NotNull().NotEmpty().Length(5).WithMessage("Zip length must be 5")
                .Matches("^[0-9]*$").WithMessage("Zip must contain only numbers");

            RuleFor(s => s.Role).NotNull().IsInEnum();
        }
    }
}
