using AutoMapper;
using Base.Mappers;
using DomainRoom = Domain.Rooms.Room;
using BLLRoom = BLL.DTO.Rooms.Room;

namespace App.BLL.Mappers.Rooms;

public class RoomMapper : BaseMapper<DomainRoom, BLLRoom>
{
    public RoomMapper(IMapper mapper) : base(mapper)
    {
    }
}