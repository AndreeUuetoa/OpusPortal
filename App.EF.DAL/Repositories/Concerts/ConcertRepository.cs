using App.DAL.Contracts.Repositories.Concerts;
using Base;
using Domain.Concerts;

namespace DAL.Repositories.Concerts;

public class ConcertRepository : EFBaseRepository<Concert, AppDbContext>, IConcertRepository
{
    public ConcertRepository(AppDbContext dbContext) : base(dbContext)
    {
    }
}