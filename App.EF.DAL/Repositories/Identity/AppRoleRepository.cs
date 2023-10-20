using App.DAL.Contracts.Repositories.Identity;
using Base;
using Domain.Identity;

namespace DAL.Repositories.Identity;

public class AppRoleRepository : EFBaseReadOnlyRepository<AppRole, AppDbContext>, IAppRoleRepository
{
    public AppRoleRepository(AppDbContext dbContext) : base(dbContext)
    {
    }
}