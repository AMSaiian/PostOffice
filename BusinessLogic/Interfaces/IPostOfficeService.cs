using BusinessLogic.Models;

namespace BusinessLogic.Interfaces
{
    public interface IPostOfficeService
    {
        Task<Result<PostOfficeModel>> GetByIdAsync(Guid id);
        Task<Result<IEnumerable<PostOfficeModel>>> GetAsync();
    }
}
