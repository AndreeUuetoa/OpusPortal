using App.DAL.Contracts.Repositories.Identity;
using Base;
using Domain.Identity;

namespace DAL.Repositories.Identity;

public class AppUserRepository : EFBaseReadOnlyRepository<AppUser, AppDbContext>, IAppUserRepository
{
    public AppUserRepository(AppDbContext dbContext) : base(dbContext)
    {
    }
}