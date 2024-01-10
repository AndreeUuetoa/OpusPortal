using Base.Domain;
using Domain.Identity;

namespace Domain.Rooms;

public class AppUserInRoom : DomainEntityId
{
    public Guid AppUserId { get; set; }
    public AppUser? AppUser { get; set; }

    public Guid RoomId { get; set; }
    public Room? Room { get; set; }

    public DateTime From { get; set; }
    public DateTime Until { get; set; }
}