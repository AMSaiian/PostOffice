using BusinessLogic.Models;
using FluentValidation;

namespace BusinessLogic.Validation
{
    public class PostOfficeValidator : AbstractValidator<PostOfficeModel>
    {
        public PostOfficeValidator()
        {
            //RuleFor(po => po.Id).NotEmpty();

            RuleFor(po => po.Zip).NotNull().Length(5).WithMessage("Zip length must be 5")
                .Matches("^[0-9]*$").WithMessage("Zip must contain only numbers");

            RuleFor(po => po.Location).NotNull().SetValidator(new AddressModelValidator());

            //RuleFor(po => po.SendParcelsId).Must(list => list.Distinct().Count() == list.Count())
            //    .WithMessage("Send parcels id list has repeats");
            //RuleForEach(po => po.SendParcelsId).NotNull().NotEmpty();

            //RuleFor(po => po.ReceiveParcelsId).Must(list => list.Distinct().Count() == list.Count())
            //    .WithMessage("Receive parcels id list has repeats");
            //RuleForEach(po => po.ReceiveParcelsId).NotNull().NotEmpty();

            //RuleFor(po => po.OfficeStaffId).Must(list => list.Distinct().Count() == list.Count())
            //    .WithMessage("Office staff id list has repeats");
            //RuleForEach(po => po.OfficeStaffId).NotNull().NotEmpty();
        }
    }
}
