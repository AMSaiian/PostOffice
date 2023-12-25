using Data.Entities;

namespace BusinessLogic.Interfaces
{
    public interface ITokenProvider
    {
        public (string, DateTime) CreateToken(Staff userStaff);
    }
}
