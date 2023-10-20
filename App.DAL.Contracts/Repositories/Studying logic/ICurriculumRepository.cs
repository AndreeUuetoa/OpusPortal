using Base.DAL.Contracts;
using Domain.Studying_logic;

namespace App.DAL.Contracts.Repositories.Studying_logic;

public interface ICurriculumRepository : IBaseRepository<Curriculum>,
    ICurriculumRepositoryCustom<Curriculum>
{
    
}

public interface ICurriculumRepositoryCustom<TEntity>
{
    
}