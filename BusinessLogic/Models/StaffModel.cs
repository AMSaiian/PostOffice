using BusinessLogic.Interfaces;
using Data.Enums;

namespace BusinessLogic.Models
{
    public class StaffModel : IModel
    {
        public Guid? Id { get; set; }

        public string? Name { get; set; }

        public string? Surname { get; set; }

        public string? PhoneNumber { get; set; }

        public UserRole? Role { get; set; }

        public Guid? PostOfficeId { get; set; }
    }
}
