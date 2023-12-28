using BusinessLogic.Interfaces;

namespace BusinessLogic.Models
{
    public class ForGrantParcelModel : IModel
    {
        public Guid? Id { get; set; }
        
        public string? ItemCategory { get; set; }

        public string? ItemDescription { get; set; }

        public ParcelItemModel.GabaritesModel? Gabarites { get; set; }
    }
}
