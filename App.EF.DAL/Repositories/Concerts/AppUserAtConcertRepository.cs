using App.DAL.Contracts.Repositories;
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

    public override async Task<IEnumerable<AppUserAtConcert>> All()
    {
        return await RepositoryDbSet
            .Include(i => i.Concert)
            .Include(i => i.AppUser)
            .ToListAsync();
    }
}