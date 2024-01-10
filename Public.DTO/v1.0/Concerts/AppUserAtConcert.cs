using Base.DTO;
using Public.DTO.v1._0.Identity;

namespace Public.DTO.v1._0.Concerts;

public class AppUserAtConcert : DTOEntityId
{
    public Guid AppUserId { get; set; }
    public AppUser? AppUser { get; set; }

    public Guid ConcertId { get; set; }
    public Concert? Concert { get; set; }

    public DateTime From { get; set; }
    public DateTime Until { get; set; }
}