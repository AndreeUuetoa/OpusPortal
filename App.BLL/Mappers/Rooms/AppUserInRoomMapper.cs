using AutoMapper;
using Base.Mappers;
using DomainAppUserInRoom = Domain.Rooms.AppUserInRoom;
using BLLAppUserInRoom = BLL.DTO.Rooms.AppUserInRoom;

namespace App.BLL.Mappers.Rooms;

public class AppUserInRoomMapper : BaseMapper<DomainAppUserInRoom, BLLAppUserInRoom>
{
    public AppUserInRoomMapper(IMapper mapper) : base(mapper)
    {
    }
}