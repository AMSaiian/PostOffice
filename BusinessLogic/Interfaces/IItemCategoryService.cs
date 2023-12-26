using BusinessLogic.Models;

namespace BusinessLogic.Interfaces
{
    public interface IItemCategoryService
    {
        Task<Result<IEnumerable<ItemCategoryModel>>> GetAsync();
    }
}
