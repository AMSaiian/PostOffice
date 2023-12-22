using Data.Context;
using Data.Entities;
using Data.Interfaces;

namespace Data.Initialisers
{
    public class ContextInitialiser : IInitialiser
    {
        private readonly PostOfficeContext _context;

        private readonly IDataSeed _seed;

        public ContextInitialiser(PostOfficeContext context, IDataSeed seed)
        {
            _context = context;
            _seed = seed;
        }

        public async Task InitialiseAsync()
        {
            try
            {
                await InitialiseEntity<ShipmentMark>(_seed.Marks);
                await _context.SaveChangesAsync();
            }
            catch (ArgumentException) {}

            try
            {
                await InitialiseEntity<Position>(_seed.Positions);
                await _context.SaveChangesAsync();
            }
            catch (ArgumentException) {}

            try
            {
                await InitialiseEntity<ItemCategory>(_seed.Categories);
                await _context.SaveChangesAsync();
            }
            catch (ArgumentException) {}

            try
            {
                await InitialiseEntity<CategoryMark>(_seed.CategoryMarks);
                await _context.SaveChangesAsync();
            }
            catch (ArgumentException) {}

            try
            {
                await InitialiseEntity<PostOffice>(_seed.Offices);
                await _context.SaveChangesAsync();
            }
            catch (ArgumentException) {}

            try
            {
                await InitialiseEntity<Staff>(_seed.Staff);
                await _context.SaveChangesAsync();
            }
            catch (ArgumentException) {}

            try
            {
                await InitialiseEntity<Client>(_seed.Clients);
                await _context.SaveChangesAsync();
            }
            catch (ArgumentException) {}

            try
            {
                await InitialiseEntity<Parcel>(_seed.Parcels);
                await _context.SaveChangesAsync();
            }
            catch (ArgumentException) {}

            try
            {
                await InitialiseEntity<ParcelStatusHistory>(_seed.StatusHistory);
                await _context.SaveChangesAsync();
            }
            catch (ArgumentException) {}

            try
            {
                await InitialiseEntity<ParcelItem>(_seed.ParcelItems);
                await _context.SaveChangesAsync();
            }
            catch (ArgumentException) {}


        }

        private async Task InitialiseEntity<TEntity>(IList<TEntity> entities) where TEntity : class, IEntity
        {
            EntityInitialiser<TEntity> initialiser = new(_context.Set<TEntity>(), entities);
            await initialiser.InitialiseAsync();
        }
    }
}
