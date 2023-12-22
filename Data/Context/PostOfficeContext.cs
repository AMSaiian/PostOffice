using Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Context
{
    public class PostOfficeContext : DbContext
    {
        public DbSet<Client> Clients { get; set; }

        public DbSet<ItemCategory> ItemCategories { get; set; }

        public DbSet<Parcel> Parcels { get; set; }

        public DbSet<ParcelItem> ParcelsItem { get; set; }

        public DbSet<ParcelStatusHistory> ParcelsStatusHistory { get; set; }

        public DbSet<Position> Positions { get; set; }

        public DbSet<PostOffice> PostOffices { get; set; }

        public DbSet<ShipmentMark> ShipmentMarks { get; set; }

        public DbSet<Staff> Staff { get; set; }

        public DbSet<CategoryMark> CategoryMarks { get; set; }

        public PostOfficeContext()
        {
        }

        public PostOfficeContext(DbContextOptions<PostOfficeContext> options) 
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ClientConfiguration());

            modelBuilder.ApplyConfiguration(new StaffConfiguration());

            modelBuilder.ApplyConfiguration(new PositionConfiguration());

            modelBuilder.ApplyConfiguration(new PostOfficeConfiguration());

            modelBuilder.ApplyConfiguration(new ShipmentMarkConfiguration());

            modelBuilder.ApplyConfiguration(new ParcelConfiguration());

            modelBuilder.ApplyConfiguration(new ItemCategoryConfiguration());

            modelBuilder.ApplyConfiguration(new CategoryMarkConfiguration());
        }
    }
}
