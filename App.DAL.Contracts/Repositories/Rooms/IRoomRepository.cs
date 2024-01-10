using Base.DAL.Contracts;
using Domain.Rooms;

namespace App.DAL.Contracts.Repositories.Rooms;

public interface IRoomRepository : IBaseRepository<Room>, IRoomRepositoryCustom<Room>
{
    
}

public interface IRoomRepositoryCustom<TEntity>
{
    
}