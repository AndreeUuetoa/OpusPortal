using Base.DAL.Contracts;
using Domain.Identity;

namespace App.DAL.Contracts.Repositories.Identity;

public interface IAppUserRepository : IBaseReadOnlyRepository<AppUser>,
    IAppUserRepositoryCustom<AppUser>
{
    
}

public interface IAppUserRepositoryCustom<TEntity>
{
    
}