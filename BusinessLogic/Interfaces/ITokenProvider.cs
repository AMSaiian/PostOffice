using Data.Entities;

namespace BusinessLogic.Interfaces
{
    public interface ITokenProvider
    {
        public string CreateToken(Staff userStaff);
    }
}
