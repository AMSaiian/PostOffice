using BusinessLogic.Interfaces;

namespace BusinessLogic.Models
{
    public class StaffDisplayModel : IModel
    {
        public Guid? Id { get; set; }

        public string? Name { get; set; }

        public string? Surname { get; set; }

        public string? PhoneNumber { get; set; }

        public string? Zip { get; set; }
    }
}
