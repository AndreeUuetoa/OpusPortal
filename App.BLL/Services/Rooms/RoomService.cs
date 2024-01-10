using App.BLL.Contracts.Services.Rooms;
using App.DAL.Contracts;
using App.DAL.Contracts.Repositories.Rooms;
using Base;
using Base.BLL;
using DomainRoom = Domain.Rooms.Room;
using BLLRoom = BLL.DTO.Rooms.Room;

namespace App.BLL.Services.Rooms;

public class RoomService : BaseEntityService<DomainRoom, BLLRoom, IRoomRepository>, IRoomService
{
    private readonly IAppUOW _uow;
    
    public RoomService(IAppUOW uow, IMapper<DomainRoom, BLLRoom> mapper) : base(uow.RoomRepository, mapper)
    {
        _uow = uow;
    }
}