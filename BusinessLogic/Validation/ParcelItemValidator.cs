using BusinessLogic.Models;
using FluentValidation;

namespace BusinessLogic.Validation
{
    public class ParcelItemValidator : AbstractValidator<ParcelItemModel>
    {
        public ParcelItemValidator()
        {
            //RuleFor(pi => pi.Id).NotEmpty();

            RuleFor(pi => pi.Description).NotNull().NotEmpty().Matches(@"^[A-Za-z.,'\s\-]+$");

            RuleFor(pi => pi.Characteristics).NotNull().SetValidator(new GabaritesModelValidation());

            //RuleFor(pi => pi.ItemCategoryId).NotNull().NotEmpty();

            //RuleFor(pi => pi.ParcelId).NotNull().NotEmpty();
        }
    }
}
