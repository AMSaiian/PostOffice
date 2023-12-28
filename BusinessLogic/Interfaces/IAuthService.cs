using BusinessLogic.Models;

namespace BusinessLogic.Interfaces
{
    public interface IAuthService
    {
        public Task<Result<TokenResponce>> LoginAsync(AuthModel credits);

        public Task<Result<object>> RegisterAsync(StaffRegisterModel newUserStaff);
    }
}
