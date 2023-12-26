using BusinessLogic.Models;
using FluentValidation;

namespace BusinessLogic.Validation
{
    public class ParcelValidator : AbstractValidator<ParcelModel>
    {
        public ParcelValidator()
        {
            //RuleFor(p => p.Id).NotEmpty();

            RuleFor(p => p.Status).NotNull().IsInEnum();

            //RuleFor(p => p.OfficeFromId).NotNull().NotEmpty();

            //RuleFor(p => p.OfficeToId).NotNull().NotEmpty();

            //RuleFor(p => p.ReceiverId).NotNull().NotEmpty();

            //RuleFor(p => p.SenderId).NotNull().NotEmpty();

            //RuleFor(p => p.ParcelFillingId).Must(list => list.Distinct().Count() == list.Count())
            //    .WithMessage("Parcel filling id list has repeats");
            //RuleForEach(p => p.ParcelFillingId).NotNull().NotEmpty();

            //RuleFor(p => p.ParcelHistoryId).Must(list => list.Distinct().Count() == list.Count())
            //    .WithMessage("Parcel history id list has repeats");
            //RuleForEach(p => p.ParcelHistoryId).NotNull().NotEmpty();
        }
    }
}
