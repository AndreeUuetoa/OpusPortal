using Base.BLL.Contracts;
using Base.DAL.Contracts;
using Base.Domain.Contracts;
using Base.DTO.Contracts;

namespace Base.BLL;

public abstract class BaseIdentityService<TDALEntity, TBLLEntity, TRepository> : BaseIdentityService<TDALEntity, TBLLEntity, TRepository, Guid>, IBaseIdentityService<TBLLEntity>
    where TBLLEntity : class, IDTOEntityId
    where TDALEntity : class, IDomainEntityId
    where TRepository : IBaseReadOnlyRepository<TDALEntity, Guid>
{
    protected BaseIdentityService(TRepository repository, IMapper<TDALEntity, TBLLEntity> mapper) : base(repository, mapper)
    {
    }
}

public abstract class BaseIdentityService<TDALEntity, TBLLEntity, TRepository, TKey> : IBaseIdentityService<TBLLEntity, TKey> 
    where TBLLEntity : class, IDTOEntityId<TKey>
    where TDALEntity : class, IDomainEntityId<TKey>
    where TRepository : IBaseReadOnlyRepository<TDALEntity, TKey>
    where TKey : struct, IEquatable<TKey>
{
    protected readonly TRepository Repository;
    protected readonly IMapper<TDALEntity, TBLLEntity> Mapper;

    protected BaseIdentityService(TRepository repository, IMapper<TDALEntity, TBLLEntity> mapper)
    {
        Repository = repository;
        Mapper = mapper;
    }

    public virtual async Task<IEnumerable<TBLLEntity>> All()
    {
        return (await Repository.All()).Select(e => Mapper.Map(e));
    }

    public virtual async Task<TBLLEntity?> Find(TKey id)
    {
        return Mapper.Map(await Repository.Find(id));
    }
}