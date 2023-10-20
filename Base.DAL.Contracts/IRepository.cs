namespace Base.DAL.Contracts;

public interface IRepository<TEntity> : IRepository<TEntity, Guid> 
    where TEntity : class
{
    
}

public interface IRepository<TEntity, in TKey> 
    where TEntity : class
    where TKey : struct, IEquatable<TKey>
{
    
}