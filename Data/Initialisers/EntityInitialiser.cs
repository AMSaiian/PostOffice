using Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Data.Initialisers
{
    public class EntityInitialiser<TEntity> : IInitialiser 
        where TEntity : class, IEntity
    {
        private readonly DbSet<TEntity> _entityDbSet;

        private readonly IList<TEntity> _entities;

        public EntityInitialiser(DbSet<TEntity> entityDbSet, IList<TEntity> entities)
        {
            _entityDbSet = entityDbSet;
            _entities = entities;
        }

        public async Task InitialiseAsync()
        {
            if (_entityDbSet.Any())
                throw new ArgumentException($"{typeof(TEntity)} db set is already initialised");

            await _entityDbSet.AddRangeAsync(_entities);
        }
    }
}
