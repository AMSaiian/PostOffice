using BusinessLogic.Interfaces;

namespace BusinessLogic.Models
{
    public class ClientModel : IModel
    {
        public Guid? Id { get; set; }

        public string? Name { get; set; }

        public string? Surname { get; set; }

        public string? PhoneNumber { get; set; }
    }
}
