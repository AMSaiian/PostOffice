using BusinessLogic.Models;
using FluentValidation;

namespace BusinessLogic.Validation
{
    public class PositionValidator : AbstractValidator<PositionModel>
    {
        public PositionValidator()
        {
            //RuleFor(p => p.Id).NotEmpty();

            RuleFor(p => p.Name).NotNull().NotEmpty().Matches(@"^[A-Za-z.,'\s\-]+$");

            RuleFor(p => p.StaffId).Must(list => list.Distinct().Count() == list.Count())
                .WithMessage("Staff id list has repeats");
            RuleForEach(p => p.StaffId).NotNull().NotEmpty();
        }
    }
}
