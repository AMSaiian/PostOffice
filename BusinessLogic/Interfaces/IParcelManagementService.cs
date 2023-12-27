using BusinessLogic.Models;

namespace BusinessLogic.Interfaces
{
    public interface IParcelManagementService
    {
        public Task<Result<object>> CreateParcelAsync(
            ClientModel sender, ClientModel receiver,
            PostOfficeModel officeFrom, PostOfficeModel officeTo,
            IEnumerable<ParcelItemModel> items);

        public Task<Result<object>> ChangeParcelStatusAsync(ParcelStatusHistoryModel statusModel);

        public Task<Result<IEnumerable<ArrivedParcelModel>>> GetParcelsInOfficeAsync(string zip);

        public Task<Result<IEnumerable<ParcelModel>>> GetClientArrivedParcelsAsync(ClientModel clientModel);
    }
}
