using BusinessLogic.Interfaces;

namespace BusinessLogic.Models
{
    public class TokenResponce : IModel
    {
        public string? JwtToken { get; set; }
    }
}
