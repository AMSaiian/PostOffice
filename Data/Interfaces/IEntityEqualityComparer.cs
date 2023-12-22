namespace Data.Interfaces
{
    public interface IEntityEqualityComparer<TEntity> : IEqualityComparer<TEntity> 
        where TEntity : class, IEntity
    {
    }
}
