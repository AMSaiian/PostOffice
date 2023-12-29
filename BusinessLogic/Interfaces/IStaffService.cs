using BusinessLogic.Models;
using Data.Enums;

namespace BusinessLogic.Interfaces
{
    public interface IStaffService
    {
        public Task<Result<IEnumerable<StaffDisplayModel>>> GetStaffByFiltersAsync(UserRole? role, string? zip);

        public Task<Result<object>> DeleteStaff(Guid id);
    }
}
