using Base.DAL.Contracts;
using Domain.Competitions;

namespace App.DAL.Contracts.Repositories.Competitions;

public interface IJuryMemberRepository : IBaseRepository<JuryMember>, IJuryMemberRepositoryCustom<JuryMember>
{
    
}

public interface IJuryMemberRepositoryCustom<TEntity>
{
    
}