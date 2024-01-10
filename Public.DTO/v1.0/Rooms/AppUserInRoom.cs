using Base.DTO;
using Public.DTO.v1._0.Identity;

namespace Public.DTO.v1._0.Rooms;

public class AppUserInRoom : DTOEntityId
{
    public Guid AppUserId { get; set; }
    public AppUser? AppUser { get; set; }

    public Guid RoomId { get; set; }
    public Room? Room { get; set; }

    public DateTime From { get; set; }
    public DateTime Until { get; set; }
}