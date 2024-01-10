using Base.DTO;
using BLL.DTO.Identity;

namespace BLL.DTO.Concerts;

public class AppUserAtConcert : DTOEntityId
{
    public Guid AppUserId { get; set; }
    public AppUser? AppUser { get; set; }

    public Guid ConcertId { get; set; }
    public Concert? Concert { get; set; }
}