using Base.DAL.Contracts;
using Domain.Studying_logic;

namespace App.DAL.Contracts.Repositories.Studying_logic;

public interface IPersonOnSubjectRepository : IBaseRepository<AppUserOnSubject>,
    IPersonOnSubjectRepositoryCustom<AppUserOnSubject>
{
    
}

public interface IPersonOnSubjectRepositoryCustom<TEntity>
{
    
}