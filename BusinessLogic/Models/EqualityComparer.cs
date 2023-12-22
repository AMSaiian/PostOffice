using BusinessLogic.Interfaces;

namespace BusinessLogic.Models
{
    public class CategoryMarkModelEqualityComparer : IModelEqualityComparer<CategoryMarkModel>
    {
        public bool Equals(CategoryMarkModel? x, CategoryMarkModel? y)
        {
            if (x == null && y == null)
                return true;
            if (x == null || y == null)
                return false;

            return x.CategoryId == y.CategoryId ||
                   x.MarkId == y.MarkId;
        }

        public int GetHashCode(CategoryMarkModel obj)
        {
            return obj.GetHashCode();
        }
    }

    public class ClientModelEqualityComparer : IModelEqualityComparer<ClientModel>
    {
        public bool Equals(ClientModel? x, ClientModel? y)
        {
            if (x == null && y == null)
                return true;
            if (x == null || y == null)
                return false;

            return x.Id == y.Id ||
                   x.PhoneNumber == y.PhoneNumber;
        }

        public int GetHashCode(ClientModel obj)
        {
            return obj.GetHashCode();
        }
    }

    public class ItemCategoryModelEqualityComparer : IModelEqualityComparer<ItemCategoryModel>
    {
        public bool Equals(ItemCategoryModel? x, ItemCategoryModel? y)
        {
            if (x == null && y == null)
                return true;
            if (x == null || y == null)
                return false;

            return x.Id == y.Id ||
                   x.Name == y.Name;
        }

        public int GetHashCode(ItemCategoryModel obj)
        {
            return obj.GetHashCode();
        }
    }

    public class ParcelItemModelEqualityComparer : IModelEqualityComparer<ParcelItemModel>
    {
        public bool Equals(ParcelItemModel? x, ParcelItemModel? y)
        {
            if (x == null && y == null)
                return true;
            if (x == null || y == null)
                return false;

            return x.Id == y.Id;
        }

        public int GetHashCode(ParcelItemModel obj)
        {
            return obj.GetHashCode();
        }
    }

    public class ParcelModelEqualityComparer : IModelEqualityComparer<ParcelModel>
    {
        public bool Equals(ParcelModel? x, ParcelModel? y)
        {
            if (x == null && y == null)
                return true;
            if (x == null || y == null)
                return false;

            return x.Id == y.Id;
        }

        public int GetHashCode(ParcelModel obj)
        {
            return obj.GetHashCode();
        }
    }

    public class ParcelStatusHistoryModelEqualityComparer : IModelEqualityComparer<ParcelStatusHistoryModel>
    {
        public bool Equals(ParcelStatusHistoryModel? x, ParcelStatusHistoryModel? y)
        {
            if (x == null && y == null)
                return true;
            if (x == null || y == null)
                return false;

            return x.Id == y.Id;
        }

        public int GetHashCode(ParcelStatusHistoryModel obj)
        {
            return obj.GetHashCode();
        }
    }

    public class PositionModelEqualityComparer : IModelEqualityComparer<PositionModel>
    {
        public bool Equals(PositionModel? x, PositionModel? y)
        {
            if (x == null && y == null)
                return true;
            if (x == null || y == null)
                return false;

            return x.Id == y.Id ||
                   x.Name == y.Name;
        }

        public int GetHashCode(PositionModel obj)
        {
            return obj.GetHashCode();
        }
    }
    
    public class PostOfficeModelEqualityComparer : IModelEqualityComparer<PostOfficeModel>
    {
        public bool Equals(PostOfficeModel? x, PostOfficeModel? y)
        {
            if (x == null && y == null)
                return true;
            if (x == null || y == null)
                return false;

            return x.Id == y.Id ||
                   x.Zip == y.Zip;
        }

        public int GetHashCode(PostOfficeModel obj)
        {
            return obj.GetHashCode();
        }
    }

    
    public class ShipmentMarkModelEqualityComparer : IModelEqualityComparer<ShipmentMarkModel>
    {
        public bool Equals(ShipmentMarkModel? x, ShipmentMarkModel? y)
        {
            if (x == null && y == null)
                return true;
            if (x == null || y == null)
                return false;

            return x.Id == y.Id ||
                   x.ShipmentConstraint == y.ShipmentConstraint;
        }

        public int GetHashCode(ShipmentMarkModel obj)
        {
            return obj.GetHashCode();
        }
    }

    public class StaffModelEqualityComparer : IModelEqualityComparer<StaffModel>
    {
        public bool Equals(StaffModel? x, StaffModel? y)
        {
            if (x == null && y == null)
                return true;
            if (x == null || y == null)
                return false;

            return x.Id == y.Id ||
                   x.PhoneNumber == y.PhoneNumber;
        }

        public int GetHashCode(StaffModel obj)
        {
            return obj.GetHashCode();
        }
    }
}
