using Base.DAL.Contracts;
using Domain.Studying_logic;

namespace App.DAL.Contracts.Repositories.Studying_logic;

public interface IPersonOnCurriculumRepository : IBaseRepository<AppUserOnCurriculum>,
    IPersonOnCurriculumRepositoryCustom<AppUserOnCurriculum>
{
    
}

public interface IPersonOnCurriculumRepositoryCustom<TEntity>
{
    
}