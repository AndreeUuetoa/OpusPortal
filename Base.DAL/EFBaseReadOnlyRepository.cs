using Base.DAL.Contracts;
using Base.Domain.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Base;

public abstract class EFBaseReadOnlyRepository<TEntity, TDbContext>: EFBaseReadOnlyRepository<TEntity, Guid, TDbContext>
    where TEntity : class, IDomainEntityId
    where TDbContext : DbContext
{
    protected EFBaseReadOnlyRepository(TDbContext dbContext) : base(dbContext)
    {
    }
}

public abstract class EFBaseReadOnlyRepository<TEntity, TKey, TDbContext> : IBaseReadOnlyRepository<TEntity, TKey>
    where TEntity : class, IDomainEntityId<TKey>
    where TKey : struct, IEquatable<TKey>
    where TDbContext : DbContext
{
    protected readonly DbSet<TEntity> RepositoryDbSet;

    protected EFBaseReadOnlyRepository(TDbContext dbContext)
    {
        var repositoryDbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        RepositoryDbSet = repositoryDbContext.Set<TEntity>();
    }

    public virtual async Task<IEnumerable<TEntity>> All()
    {
        return await RepositoryDbSet.AsNoTracking().ToListAsync();
    }

    public virtual async Task<TEntity?> Find(TKey id)
    {
        return await RepositoryDbSet.FindAsync(id);
    }
}