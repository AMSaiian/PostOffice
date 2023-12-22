using BusinessLogic.Models;

namespace BusinessLogic.Interfaces
{
    public interface IParcelManagementService
    {
        public Task CreateParcelAsync(
            ClientModel sender, ClientModel receiver,
            PostOfficeModel officeFrom, PostOfficeModel officeTo,
            IEnumerable<ParcelItemModel> items);
    }
}
