using BusinessLogic.Interfaces;

namespace BusinessLogic.Models
{
    public class TokenResponce : IModel
    {
        public string? JwtToken { get; set; }

        public Guid? StaffId { get; set; }

        public string? Fullname { get; set; }

        public string? Role { get; set; }

        public string? PostOfficeZip { get; set; }

        public DateTime? ExpireTime { get; set; }
    }
}
