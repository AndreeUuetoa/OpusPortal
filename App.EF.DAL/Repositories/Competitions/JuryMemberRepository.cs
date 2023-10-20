using App.DAL.Contracts.Repositories.Competitions;
using Base;
using Domain.Competitions;

namespace DAL.Repositories.Competitions;

public class JuryMemberRepository : EFBaseRepository<JuryMember, AppDbContext>, IJuryMemberRepository
{
    public JuryMemberRepository(AppDbContext dbContext) : base(dbContext)
    {
    }
}