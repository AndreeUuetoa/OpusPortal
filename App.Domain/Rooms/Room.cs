using System.ComponentModel.DataAnnotations;
using Base.Domain;

namespace Domain.Rooms;

public class Room : DomainEntityId
{
    [MinLength(1)]
    [MaxLength(256)]
    public string RoomNumber { get; set; } = default!;

    public ICollection<AppUserInRoom>? AppUserInRooms { get; set; }
}