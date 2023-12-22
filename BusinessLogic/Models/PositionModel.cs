using BusinessLogic.Interfaces;

namespace BusinessLogic.Models
{
    public class PositionModel : IModel
    {
        public Guid? Id { get; set; }

        public string? Name { get; set; }

        public IList<Guid> StaffId { get; set; }
    }
}
