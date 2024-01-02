using BusinessLogic.Models;
using FluentValidation;

namespace BusinessLogic.Validation
{
    public class ClientValidator : AbstractValidator<ClientModel>
    {
        public ClientValidator()
        {
            RuleFor(c => c.Name).Cascade(CascadeMode.Stop)
                .NotNull().WithMessage("Sender and receiver names must be defined")
                .NotEmpty().WithMessage("Sender and receiver names must be defined")
                .Matches(@"^[A-Za-z.,'\s\-]+$").WithMessage("Sender and receiver names must contain only letters");

            RuleFor(c => c.Surname).Cascade(CascadeMode.Stop)
                .NotNull().WithMessage("Sender and receiver surnames must be defined")
                .NotEmpty().WithMessage("Sender and receiver surnames must be defined")
                .Matches(@"^[A-Za-z.,'\s\-]+$").WithMessage("Sender and receiver surnames must contain only letters");

            RuleFor(c => c.PhoneNumber).Cascade(CascadeMode.Stop)
                .NotNull().WithMessage("Sender and receiver phone numbers must be defined")
                .NotEmpty().WithMessage("Sender and receiver phone numbers must be defined")
                .Matches(@"^\+380\d{9}$").WithMessage("Sender and receiver phone number must be like +380XXXXXXXXX");
        }
    }
}
