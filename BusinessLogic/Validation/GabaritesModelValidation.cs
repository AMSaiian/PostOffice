using BusinessLogic.Models;
using FluentValidation;

namespace BusinessLogic.Validation
{
    public class GabaritesModelValidation : AbstractValidator<ParcelItemModel.GabaritesModel>
    {
        public GabaritesModelValidation()
        {
            RuleFor(g => g.Depth).Cascade(CascadeMode.Stop)
                .NotNull().WithMessage("Depth must be defined")
                .GreaterThan(0).WithMessage("Depth must be greater than 0 mm");

            RuleFor(g => g.Width).Cascade(CascadeMode.Stop)
                .NotNull().WithMessage("Width must be defined")
                .GreaterThan(0).WithMessage("Width must be greater than 0 mm");;

            RuleFor(g => g.Height).Cascade(CascadeMode.Stop)
                .NotNull().WithMessage("Height must be defined")
                .GreaterThan(0).WithMessage("Height must be greater than 0 mm");;

            RuleFor(g => g.Weight).Cascade(CascadeMode.Stop)
                .NotNull().WithMessage("Weight must be defined")
                .GreaterThan(0.001).WithMessage("Weight must be greater than 1 g");
        }
    }
}
