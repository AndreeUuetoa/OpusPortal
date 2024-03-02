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
    private readonly IAppDAL _dal;
    
    public RoomService(IAppDAL dal, IMapper<DomainRoom, BLLRoom> mapper) : base(dal.RoomRepository, mapper)
    {
        _dal = dal;
    }
}