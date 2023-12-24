using Data.Entities;

namespace Data.Interfaces;

public interface IDataSeed
{
    public IList<ShipmentMark> Marks { get; }

    public IList<ItemCategory> Categories { get; }

    public IList<CategoryMark> CategoryMarks { get; }

    public IList<Parcel> Parcels { get; }

    public IList<ParcelItem> ParcelItems { get; }

    public IList<ParcelStatusHistory> StatusHistory { get; }

    public IList<PostOffice> Offices { get; }

    public IList<Client> Clients { get; }

    public IList<Staff> Staff { get; }
}