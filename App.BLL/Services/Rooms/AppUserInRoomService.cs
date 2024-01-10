using App.BLL.Contracts.Services.Rooms;
using App.DAL.Contracts;
using App.DAL.Contracts.Repositories.Rooms;
using Base;
using Base.BLL;
using DomainAppUserInRoom = Domain.Rooms.AppUserInRoom;
using BLLAppUserInRoom = BLL.DTO.Rooms.AppUserInRoom;

namespace App.BLL.Services.Rooms;

public class AppUserInRoomService : BaseEntityService<DomainAppUserInRoom, BLLAppUserInRoom, IAppUserInRoomRepository>, IAppUserInRoomService
{
    private readonly IAppUOW _uow;
    
    public AppUserInRoomService(IAppUOW uow, IMapper<DomainAppUserInRoom, BLLAppUserInRoom> mapper) : base(uow.AppUserInRoomRepository, mapper)
    {
        _uow = uow;
    }

    public async Task<IEnumerable<BLLAppUserInRoom>> AllWithUserId(Guid id)
    {
        return (await _uow.AppUserInRoomRepository.AllWithUserId(id)).Select(e => Mapper.Map(e));
    }
}