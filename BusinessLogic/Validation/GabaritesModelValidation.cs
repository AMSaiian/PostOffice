using BusinessLogic.Models;
using FluentValidation;

namespace BusinessLogic.Validation
{
    public class GabaritesModelValidation : AbstractValidator<ParcelItemModel.GabaritesModel>
    {
        public GabaritesModelValidation()
        {
            RuleFor(g => g.Depth).NotNull().GreaterThan(0);

            RuleFor(g => g.Width).NotNull().GreaterThan(0);

            RuleFor(g => g.Height).NotNull().GreaterThan(0);

            RuleFor(g => g.Weight).NotNull().GreaterThan(0.001);
        }
    }
}
