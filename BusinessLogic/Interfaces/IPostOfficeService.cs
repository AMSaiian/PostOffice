using BusinessLogic.Models;

namespace BusinessLogic.Interfaces
{
    public interface IPostOfficeService
    {
        Task<PostOfficeModel> GetByIdAsync(Guid id);
        Task<IEnumerable<PostOfficeModel>> GetAsync();
        Task AddAsync(PostOfficeModel model);
        Task UpdateAsync(PostOfficeModel model);
        Task DeleteAsync(Guid id);
    }
}
