using BusinessLogic.Models;
using FluentValidation;

namespace BusinessLogic.Validation
{
    public class AuthModelValidator : AbstractValidator<AuthModel>
    {
        public AuthModelValidator()
        {
            RuleFor(x => x.PhoneNumber).Cascade(CascadeMode.Stop)
                .NotNull().WithMessage("Phone number must be defined")
                .NotEmpty().WithMessage("Phone number must be defined")
                .Matches(@"^\+380\d{9}$").WithMessage("Phone number must be like +380XXXXXXXXX");
            RuleFor(x => x.Password).Cascade(CascadeMode.Stop)
                .NotNull().WithMessage("Password must be defined")
                .NotEmpty().WithMessage("Password must be defined")
                .MinimumLength(8).WithMessage("Password must has minimum 8 symbols");
        }
    }
}
