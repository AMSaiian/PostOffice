using BusinessLogic.Models;

namespace BusinessLogic.Interfaces
{
    public interface IPostOfficeService
    {
        Task<Result<PostOfficeModel>> GetByIdAsync(Guid id);
        Task<Result<IEnumerable<PostOfficeModel>>> GetAsync();
        Task<Result<object>> AddAsync(PostOfficeModel model);
        Task<Result<object>> UpdateAsync(PostOfficeModel model);
        Task<Result<object>> DeleteAsync(Guid id);
    }
}
