using App.DAL.Contracts.Repositories.Competitions;
using Base;
using Domain.Competitions;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories.Competitions;

public class CompetitionRepository : EFBaseRepository<Competition, AppDbContext>, ICompetitionRepository
{
    public CompetitionRepository(AppDbContext dbContext) : base(dbContext)
    {
    }

    public override async Task<IEnumerable<Competition>> All()
    {
        return await RepositoryDbSet
            .Include(c => c.Concerts)
            .ToListAsync();
    }
}