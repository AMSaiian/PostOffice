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
            self.AddScoped<IItemCategoryService, ItemCategoryService>();
            self.AddScoped<IAuthService, AuthService>();
            self.AddScoped<IStaffService, StaffService>();
            
            return self;
        }

        public static IServiceCollection AddValidators(this IServiceCollection self)
        {
            self.AddScoped<ClientValidator>();
            self.AddScoped<ItemCategoryValidator>();
            self.AddScoped<ParcelItemValidator>();
            self.AddScoped<ParcelStatusHistoryValidator>();
            self.AddScoped<ParcelValidator>();
            self.AddScoped<PostOfficeValidator>();
            self.AddScoped<StaffRegisterValidator>();
            self.AddScoped<AuthModelValidator>();
            
            return self;
        }
    }
}
