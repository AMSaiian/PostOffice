using BusinessLogic.Models;
using FluentValidation;

namespace BusinessLogic.Validation
{
    public class ClientValidator : AbstractValidator<ClientModel>
    {
        public ClientValidator()
        {
            //RuleFor(c => c.Id).NotEmpty();

            RuleFor(c => c.Name).NotNull().NotEmpty().Matches(@"^[A-Za-z.,'\s\-]+$");

            RuleFor(c => c.Surname).NotNull().NotEmpty().Matches(@"^[A-Za-z.,'\s\-]+$");

            RuleFor(c => c.PhoneNumber).NotNull().NotEmpty().Matches(@"^\+380\d{9}$");

            //RuleFor(c => c.Email).EmailAddress().When(c => c.Email is not null);

            //RuleFor(c => c.SentParcelsId).Must(list => list.Distinct().Count() == list.Count())
            //    .WithMessage("Sent parcels id list has repeats");
            //RuleForEach(c => c.SentParcelsId).NotNull().NotEmpty();

            //RuleFor(c => c.AddressedParcelsId).Must(list => list.Distinct().Count() == list.Count())
            //    .WithMessage("Addressed parcels id list has repeats");
            //RuleForEach(c => c.AddressedParcelsId).NotNull().NotEmpty();
        }
    }
}
