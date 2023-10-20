using Base.Domain;
using Domain.Concerts;
using Domain.Identity;

namespace Domain.Competitions;

public class JuryMember : DomainEntityId
{
    public Guid ConcertId { get; set; }
    public Concert? Concert { get; set; }

    public Guid AppUserId { get; set; }
    public AppUser? AppUser { get; set; }

    public DateTime From { get; set; }
    public DateTime Until { get; set; }
}