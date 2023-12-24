using BusinessLogic.Interfaces;
using BusinessLogic.Services;
using BusinessLogic.Services.CRUD;
using BusinessLogic.Validation;
using Data.Entities;
using Data.Interfaces;

namespace WebApi
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddServices(this IServiceCollection self)
        {
            self.AddScoped<IPostOfficeService, PostOfficeService>();
            self.AddScoped<IParcelManagementService, ParcelManagementService>();
            self.AddScoped<IAuthService, AuthService>();
            
            return self;
        }

        public static IServiceCollection AddValidators(this IServiceCollection self)
        {
            self.AddScoped<CategoryMarkValidator>();
            self.AddScoped<ClientValidator>();
            self.AddScoped<ItemCategoryValidator>();
            self.AddScoped<ParcelItemValidator>();
            self.AddScoped<ParcelStatusHistoryValidator>();
            self.AddScoped<ParcelValidator>();
            self.AddScoped<PostOfficeValidator>();
            self.AddScoped<ShipmentMarkValidator>();
            self.AddScoped<StaffValidator>();
            self.AddScoped<AuthModelValidator>();
            
            return self;
        }

        public static IServiceCollection AddComparers(this IServiceCollection self)
        {
            self.AddScoped<IEntityEqualityComparer<PostOffice>, PostOfficeEqualityComparer>();
            self.AddScoped<IEntityEqualityComparer<Parcel>, ParcelEqualityComparer>();
            self.AddScoped<IEntityEqualityComparer<ParcelStatusHistory>, ParcelStatusHistoryEqualityComparer>();
            self.AddScoped<IEntityEqualityComparer<ParcelItem>, ParcelItemEqualityComparer>();
            self.AddScoped<IEntityEqualityComparer<ItemCategory>, ItemCategoryEqualityComparer>();
            self.AddScoped<IEntityEqualityComparer<Staff>, StaffEqualityComparer>();
            self.AddScoped<IEntityEqualityComparer<ShipmentMark>, ShipmentMarkEqualityComparer>();
            self.AddScoped<IEntityEqualityComparer<Client>, ClientEqualityComparer>();
            self.AddScoped<IEntityEqualityComparer<CategoryMark>, CategoryMarkEqualityComparer>();

            return self;
        }
    }
}
