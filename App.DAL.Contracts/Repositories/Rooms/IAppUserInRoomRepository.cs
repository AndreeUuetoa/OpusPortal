using Base.DAL.Contracts;
using Domain.Rooms;

namespace App.DAL.Contracts.Repositories.Rooms;

public interface IAppUserInRoomRepository : IBaseRepository<AppUserInRoom>, IAppUserInRoomRepositoryCustom<AppUserInRoom>
{
    
}

public interface IAppUserInRoomRepositoryCustom<TEntity>
{
    Task<IEnumerable<TEntity>> AllWithUserId(Guid id);
}