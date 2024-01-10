using Base.DTO;

namespace Public.DTO.v1._0.Rooms;

public class Room : DTOEntityId
{
    public string RoomNumber { get; set; } = default!;
}