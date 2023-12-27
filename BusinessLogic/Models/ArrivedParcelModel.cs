using BusinessLogic.Interfaces;

namespace BusinessLogic.Models
{
    public class ArrivedParcelModel : IModel
    {
        public Guid? Id { get; set; }

        public string? CityFrom { get; set; }

        public string? ZipFrom { get; set; }
    }
}
