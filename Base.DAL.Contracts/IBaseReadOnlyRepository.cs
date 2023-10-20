namespace Base.DAL.Contracts;

public interface IBaseReadOnlyRepository<TEntity> : IBaseReadOnlyRepository<TEntity, Guid>
    where TEntity : class
{
    
}

public interface IBaseReadOnlyRepository<TEntity, in TKey> : IRepository<TEntity, TKey>
    where TEntity : class
    where TKey : struct, IEquatable<TKey>
{
    Task<IEnumerable<TEntity>> All();

    Task<TEntity?> Find(TKey id);
}