using Base.DAL.Contracts;
using Domain.Concerts;

namespace App.DAL.Contracts.Repositories.Concerts;

public interface IConcertRepository : IBaseRepository<Concert>, IConcertRepositoryCustom<Concert>
{
    
}

public interface IConcertRepositoryCustom<TEntity>
{
    
}