using Base.DAL.Contracts;
using Domain.Competitions;

namespace App.DAL.Contracts.Repositories.Competitions;

public interface ICompetitionRepository : IBaseRepository<Competition>, ICompetitionRepositoryCustom<Competition>
{
    
}

public interface ICompetitionRepositoryCustom<TEntity>
{
    
}