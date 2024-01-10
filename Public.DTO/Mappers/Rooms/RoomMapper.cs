using AutoMapper;
using Base.Mappers;
using BLLRoom = BLL.DTO.Rooms.Room;
using PublicRoom = Public.DTO.v1._0.Rooms.Room;

namespace Public.DTO.Mappers.Rooms;

public class RoomMapper : BaseMapper<BLLRoom, PublicRoom>
{
    public RoomMapper(IMapper mapper) : base(mapper)
    {
    }
}