using Base.Domain;

namespace Domain.Identity;

public class UserTeachingUser : DomainEntityId
{
    public Guid TeacherId { get; set; }
    public AppUser? Teacher { get; set; }
    
    public Guid StudentId { get; set; }
    public AppUser? Student { get; set; }

    public DateTime From { get; set; }
    public DateTime? Until { get; set; }
}