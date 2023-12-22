using Data.Interfaces;

namespace Data.Entities
{
    public class CategoryMarkEqualityComparer : IEntityEqualityComparer<CategoryMark>
    {
        public bool Equals(CategoryMark? x, CategoryMark? y)
        {
            if (x == null && y == null)
                return true;
            if (x == null || y == null)
                return false;

            return x.CategoryId == y.CategoryId ||
                   x.MarkId == y.MarkId;
        }

        public int GetHashCode(CategoryMark obj)
        {
            return obj.GetHashCode();
        }
    }

    public class ClientEqualityComparer : IEntityEqualityComparer<Client>
    {
        public bool Equals(Client? x, Client? y)
        {
            if (x == null && y == null)
                return true;
            if (x == null || y == null)
                return false;

            return x.Id == y.Id ||
                   x.PhoneNumber == y.PhoneNumber;
        }

        public int GetHashCode(Client obj)
        {
            return obj.GetHashCode();
        }
    }

    public class ItemCategoryEqualityComparer : IEntityEqualityComparer<ItemCategory>
    {
        public bool Equals(ItemCategory? x, ItemCategory? y)
        {
            if (x == null && y == null)
                return true;
            if (x == null || y == null)
                return false;

            return x.Id == y.Id ||
                   x.Name == y.Name;
        }

        public int GetHashCode(ItemCategory obj)
        {
            return obj.GetHashCode();
        }
    }

    public class ParcelItemEqualityComparer : IEntityEqualityComparer<ParcelItem>
    {
        public bool Equals(ParcelItem? x, ParcelItem? y)
        {
            if (x == null && y == null)
                return true;
            if (x == null || y == null)
                return false;

            return x.Id == y.Id;
        }

        public int GetHashCode(ParcelItem obj)
        {
            return obj.GetHashCode();
        }
    }

    public class ParcelEqualityComparer : IEntityEqualityComparer<Parcel>
    {
        public bool Equals(Parcel? x, Parcel? y)
        {
            if (x == null && y == null)
                return true;
            if (x == null || y == null)
                return false;

            return x.Id == y.Id;
        }

        public int GetHashCode(Parcel obj)
        {
            return obj.GetHashCode();
        }
    }

    public class ParcelStatusHistoryEqualityComparer : IEntityEqualityComparer<ParcelStatusHistory>
    {
        public bool Equals(ParcelStatusHistory? x, ParcelStatusHistory? y)
        {
            if (x == null && y == null)
                return true;
            if (x == null || y == null)
                return false;

            return x.Id == y.Id;
        }

        public int GetHashCode(ParcelStatusHistory obj)
        {
            return obj.GetHashCode();
        }
    }

    public class PositionEqualityComparer : IEntityEqualityComparer<Position>
    {
        public bool Equals(Position? x, Position? y)
        {
            if (x == null && y == null)
                return true;
            if (x == null || y == null)
                return false;

            return x.Id == y.Id ||
                   x.Name == y.Name;
        }

        public int GetHashCode(Position obj)
        {
            return obj.GetHashCode();
        }
    }
    
    public class PostOfficeEqualityComparer : IEntityEqualityComparer<PostOffice>
    {
        public bool Equals(PostOffice? x, PostOffice? y)
        {
            if (x == null && y == null)
                return true;
            if (x == null || y == null)
                return false;

            return x.Id == y.Id ||
                   x.Zip == y.Zip;
        }

        public int GetHashCode(PostOffice obj)
        {
            return obj.GetHashCode();
        }
    }

    
    public class ShipmentMarkEqualityComparer : IEntityEqualityComparer<ShipmentMark>
    {
        public bool Equals(ShipmentMark? x, ShipmentMark? y)
        {
            if (x == null && y == null)
                return true;
            if (x == null || y == null)
                return false;

            return x.Id == y.Id ||
                   x.ShipmentConstraint == y.ShipmentConstraint;
        }

        public int GetHashCode(ShipmentMark obj)
        {
            return obj.GetHashCode();
        }
    }

    public class StaffEqualityComparer : IEntityEqualityComparer<Staff>
    {
        public bool Equals(Staff? x, Staff? y)
        {
            if (x == null && y == null)
                return true;
            if (x == null || y == null)
                return false;

            return x.Id == y.Id ||
                   x.PhoneNumber == y.PhoneNumber;
        }

        public int GetHashCode(Staff obj)
        {
            return obj.GetHashCode();
        }
    }
}
