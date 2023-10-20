using App.DAL.Contracts.Repositories;
using App.DAL.Contracts.Repositories.Competitions;
using Base;
using Domain.Competitions;

namespace DAL.Repositories.Competitions;

public class CompetitionRepository : EFBaseRepository<Competition, AppDbContext>, ICompetitionRepository
{
    public CompetitionRepository(AppDbContext dbContext) : base(dbContext)
    {
    }
}