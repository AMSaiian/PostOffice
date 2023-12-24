using BusinessLogic.Interfaces;
using Data.Enums;

namespace BusinessLogic.Models
{
    public class TokenResponce : IModel
    {
        public string? JwtToken { get; set; }

        public Guid? StaffId { get; set; }

        public UserRole? Role { get; set; }

        public Guid? PostOfficeId { get; set; }
    }
}
