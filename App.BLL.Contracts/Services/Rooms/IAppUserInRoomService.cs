using Base.BLL.Contracts;
using BLL.DTO.Rooms;

namespace App.BLL.Contracts.Services.Rooms;

public interface IAppUserInRoomService : IBaseEntityService<AppUserInRoom>
{
    Task<IEnumerable<AppUserInRoom>> AllWithUserId(Guid id);
}