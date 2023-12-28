using BusinessLogic.Interfaces;

namespace BusinessLogic.Models
{
    public class ItemCategoryModel : IModel
    {
        public Guid? Id { get; set; }

        public string? Name { get; set; }
    }
}
