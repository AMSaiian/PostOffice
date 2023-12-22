using BusinessLogic.Models;

namespace WebApi.RequestWraps
{
    public record CreateParcelWrap(
            ClientModel Sender,
            ClientModel Receiver,
            PostOfficeModel OfficeFrom,
            PostOfficeModel OfficeTo,
            IEnumerable<ParcelItemModel> Items
    );
}
