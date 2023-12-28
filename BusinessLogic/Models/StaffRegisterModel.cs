using BusinessLogic.Interfaces;
using Data.Enums;

namespace BusinessLogic.Models
{
    public class StaffRegisterModel : IModel
    {
        public Guid? Id { get; set; }

        public string? Name { get; set; }

        public string? Surname { get; set; }

        public string? PhoneNumber { get; set; }

        public string? Password { get; set; }

        public string? ConfirmPassword { get; set; }

        public UserRole? Role { get; set; }

        public string? PostOfficeZip { get; set; }
    }
}
