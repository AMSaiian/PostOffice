using BusinessLogic.Interfaces;
using Data.Enums;

namespace BusinessLogic.Models
{
    public class ParcelStatusHistoryModel : IModel
    {
        public Guid? Id { get; set; }

        public ParcelStatus? Status { get; set; }

        public DateTime? ChangesTime { get; set; }

        public Guid? ParcelId { get; set; }
    }
}
