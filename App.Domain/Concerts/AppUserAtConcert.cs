using Base.Domain;
using Domain.Identity;

namespace Domain.Concerts;

public class AppUserAtConcert : DomainEntityId
{
    public Guid AppUserId { get; set; }
    public AppUser? AppUser { get; set; }

    public Guid ConcertId { get; set; }
    public Concert? Concert { get; set; }

    public DateTime From { get; set; }
    public DateTime Until { get; set; }
}