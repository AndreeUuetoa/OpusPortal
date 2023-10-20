using System.ComponentModel.DataAnnotations;
using Base.Domain;

namespace Domain.Studying_logic;

public class Room : DomainEntityId
{
    public string? Name { get; set; }
    
    [MinLength(1)]
    [MaxLength(20)]
    public string RoomNumber { get; set; } = default!;

    public ICollection<ClassInRoom>? ClassInRooms { get; set; }
}