using App.DAL.Contracts.Repositories.Concerts;
using Base;
using Domain.Concerts;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories.Concerts;

public class AppUserAtConcertRepository : EFBaseRepository<AppUserAtConcert, AppDbContext>,
    IAppUserAtConcertRepository
{
    public AppUserAtConcertRepository(AppDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<IEnumerable<AppUserAtConcert>> AllWithUserId(Guid id)
    {
        return await RepositoryDbSet
            .Include(i => i.Concert)
            .Include(i => i.AppUser)
            .Where(appUser => appUser.AppUserId == id)
            .ToListAsync();
    }
}