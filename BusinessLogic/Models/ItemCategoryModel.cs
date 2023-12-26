using BusinessLogic.Interfaces;

namespace BusinessLogic.Models
{
    public class ItemCategoryModel : IModel
    {
        public Guid? Id { get; set; }

        public string? Name { get; set; }

        //public IList<Guid> ParcelItemsId { get; set; }

        //public IList<Guid> CategoryMarksId { get; set; }
    }
}
