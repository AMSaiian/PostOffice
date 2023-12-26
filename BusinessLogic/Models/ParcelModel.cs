using BusinessLogic.Interfaces;
using Data.Enums;

namespace BusinessLogic.Models
{
    public class ParcelModel : IModel
    {
        public Guid? Id { get; set; }

        public ParcelStatus? Status { get; set; }

        public Guid? OfficeFromId { get; set; }

        public Guid? OfficeToId { get; set; }

        public Guid? SenderId { get; set; }

        public Guid? ReceiverId { get; set; }

        //public IList<Guid> ParcelFillingId { get; set; }

        //public IList<Guid> ParcelHistoryId { get; set; }
    }
}
