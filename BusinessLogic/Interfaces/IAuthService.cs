using BusinessLogic.Models;

namespace BusinessLogic.Interfaces
{
    public interface IAuthService
    {
        public Task<TokenResponce> LoginAsync(AuthModel credits);
    }
}
