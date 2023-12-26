using BusinessLogic.Models;
using FluentValidation;

namespace BusinessLogic.Validation
{
    public class ShipmentMarkValidator : AbstractValidator<ShipmentMarkModel>
    {
        public ShipmentMarkValidator()
        {
            //RuleFor(sm => sm.Id).NotEmpty();

            RuleFor(sm => sm.ShipmentConstraint).NotNull();

            RuleFor(sm => sm.PriceCoef).NotNull().GreaterThan(0);

            //RuleFor(sm => sm.CategoryMarksId).Must(list => list.Distinct().Count() == list.Count())
            //    .WithMessage("Category id list has repeats");
            //RuleForEach(sm => sm.CategoryMarksId).NotNull().NotEmpty();
        }
    }
}
