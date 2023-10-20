using Base.DAL.Contracts;
using Domain.Library;

namespace App.DAL.Contracts.Repositories.Library;

public interface IBookLentOutRepository : IBaseRepository<BookLentOut>,
    IBookLentOutRepositoryCustom<BookLentOut>
{
    
}

public interface IBookLentOutRepositoryCustom<TEntity> 
{
    Task<IEnumerable<TEntity>> AllWithUserId(Guid id);
}