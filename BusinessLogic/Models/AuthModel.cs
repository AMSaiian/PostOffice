using BusinessLogic.Interfaces;

namespace BusinessLogic.Models
{
    public class AuthModel : IModel
    {
        public string? PhoneNumber { get; set; } 

        public string? Password { get; set; } 
    }
}
