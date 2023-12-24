using BusinessLogic.Models;

namespace BusinessLogic.Interfaces
{
    public interface IAuthService
    {
        public Task<Result<TokenResponce>> LoginAsync(AuthModel credits);
    }
}
