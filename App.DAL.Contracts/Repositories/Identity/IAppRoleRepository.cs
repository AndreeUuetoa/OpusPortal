using Base.DAL.Contracts;
using Domain.Identity;

namespace App.DAL.Contracts.Repositories.Identity;

public interface IAppRoleRepository : IBaseReadOnlyRepository<AppRole>,
    IAppRoleRepositoryCustom<AppRole>
{
    
}

public interface IAppRoleRepositoryCustom<TEntity>
{
    
}