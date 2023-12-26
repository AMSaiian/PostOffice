using BusinessLogic.Interfaces;
using Data.Enums;

namespace BusinessLogic.Models
{
    public class ShipmentMarkModel : IModel
    {
        public Guid? Id { get; set; }

        public ShipmentConstraint? ShipmentConstraint { get; set; }

        public double? PriceCoef { get; set; }

        //public IList<Guid> CategoryMarksId { get; set; }
    }
}
