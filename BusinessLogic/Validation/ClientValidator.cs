using BusinessLogic.Models;
using FluentValidation;

namespace BusinessLogic.Validation
{
    public class ClientValidator : AbstractValidator<ClientModel>
    {
        public ClientValidator()
        {
            RuleFor(c => c.Name).NotNull().NotEmpty().Matches(@"^[A-Za-z.,'\s\-]+$");

            RuleFor(c => c.Surname).NotNull().NotEmpty().Matches(@"^[A-Za-z.,'\s\-]+$");

            RuleFor(c => c.PhoneNumber).NotNull().NotEmpty().Matches(@"^\+380\d{9}$");
        }
    }
}
