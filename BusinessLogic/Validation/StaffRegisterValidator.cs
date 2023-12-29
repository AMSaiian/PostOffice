using BusinessLogic.Models;
using FluentValidation;

namespace BusinessLogic.Validation
{
    public class StaffRegisterValidator : AbstractValidator<StaffRegisterModel>
    {
        public StaffRegisterValidator()
        {
            RuleFor(s => s.Name).Cascade(CascadeMode.Stop)
                .NotNull().WithMessage("Name must be defined")
                .NotEmpty().WithMessage("Name must be defined")
                .Matches(@"^[A-Za-z.,'\s\-]+$").WithMessage("Name must contain only letters");

            RuleFor(s => s.Surname).Cascade(CascadeMode.Stop)
                .NotNull().WithMessage("Surname must be defined")
                .NotEmpty().WithMessage("Surname must be defined")
                .Matches(@"^[A-Za-z.,'\s\-]+$").WithMessage("Surname must contain only letters");

            RuleFor(s => s.PhoneNumber).Cascade(CascadeMode.Stop)
                .NotNull().WithMessage("Phone numbers must be defined")
                .NotEmpty().WithMessage("Phone numbers must be defined")
                .Matches(@"^\+380\d{9}$").WithMessage("Phone number must be like +380XXXXXXXXX");

            RuleFor(s => s.Password).Cascade(CascadeMode.Stop)
                .NotNull().WithMessage("Password must be defined")
                .NotEmpty().WithMessage("Password must be defined")
                .MinimumLength(8).WithMessage("Password must has minimum 8 symbols");

            RuleFor(s => s.ConfirmPassword)
                .Equal(s => s.Password).WithMessage("Password and confirm password are mismatched");

            RuleFor(s => s.PostOfficeZip).Cascade(CascadeMode.Stop)
                .NotNull().WithMessage("Zip must be defined")
                .NotEmpty().WithMessage("Zip must be defined")
                .Length(5).WithMessage("Zip must contain 5 numbers")
                .Matches("^[0-9]*$").WithMessage("Zip must contain only numbers");

            RuleFor(s => s.Role).Cascade(CascadeMode.Stop)
                .NotNull().WithMessage("Role must be defined")
                .IsInEnum().WithMessage("Role must be defined correctly");
        }
    }
}
