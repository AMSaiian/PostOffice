using BusinessLogic.Models;
using FluentValidation;

namespace BusinessLogic.Validation
{
    public class ItemCategoryValidator : AbstractValidator<ItemCategoryModel>
    {
        public ItemCategoryValidator()
        {
            //RuleFor(ic => ic.Id).NotEmpty();

            RuleFor(ic => ic.Name).NotNull().NotEmpty().Matches(@"^[A-Za-z.,'\s\-]+$");

            //RuleFor(ic => ic.ParcelItemsId).Must(list => list.Distinct().Count() == list.Count())
            //    .WithMessage("Parcel items id list has repeats");
            //RuleForEach(ic => ic.ParcelItemsId).NotNull().NotEmpty();

            //RuleFor(ic => ic.CategoryMarksId).Must(list => list.Distinct().Count() == list.Count())
            //    .WithMessage("Marks id list has repeats");
            //RuleForEach(ic => ic.CategoryMarksId).NotNull().NotEmpty();
        }
    }
}
