using BusinessLogic.Interfaces;

namespace BusinessLogic.Models
{
    public class CategoryMarkModel : IModel
    {
        public Guid? CategoryId { get; set; }

        public Guid? MarkId { get; set; }
    }
}
