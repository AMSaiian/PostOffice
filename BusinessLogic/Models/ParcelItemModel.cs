using BusinessLogic.Interfaces;

namespace BusinessLogic.Models
{
    public class ParcelItemModel : IModel
    {
        public Guid? Id { get; set; }

        public string? Description { get; set; }

        public GabaritesModel? Characteristics { get; set; }

        public Guid? ItemCategoryId { get; set; }

        public Guid? ParcelId { get; set; }

        public class GabaritesModel
        {
            public int? Width { get; set; }

            public int? Height { get; set; }

            public int? Depth { get; set; }

            public double? Weight { get; set; }
        }
    }
}
