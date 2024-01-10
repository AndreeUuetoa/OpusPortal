using AutoMapper;
using Base.Mappers;
using BLLAppUserInRoom = BLL.DTO.Rooms.AppUserInRoom;
using PublicAppUserInRoom = Public.DTO.v1._0.Rooms.AppUserInRoom;

namespace Public.DTO.Mappers.Rooms;

public class AppUserInRoomMapper : BaseMapper<BLLAppUserInRoom, PublicAppUserInRoom>
{
    public AppUserInRoomMapper(IMapper mapper) : base(mapper)
    {
    }
}