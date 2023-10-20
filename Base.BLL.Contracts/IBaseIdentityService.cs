using Base.DTO.Contracts;

namespace Base.BLL.Contracts;

public interface IBaseIdentityService<TEntity> : IBaseIdentityService<TEntity, Guid>
    where TEntity : class, IDTOEntityId
{
    
}

public interface IBaseIdentityService<TEntity, in TKey> : IBaseService
    where TEntity : class, IDTOEntityId<TKey>
    where TKey : struct, IEquatable<TKey>
{
    Task<IEnumerable<TEntity>> All();

    Task<TEntity?> Find(TKey id);
}