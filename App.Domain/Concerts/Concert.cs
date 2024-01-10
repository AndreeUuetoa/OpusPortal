using System.ComponentModel.DataAnnotations;
using Base.Domain;
using Domain.Competitions;
using Domain.Identity;

namespace Domain.Concerts;

public class Concert : DomainEntityId
{
    public Guid? CompetitionId { get; set; }
    public Competition? Competition { get; set; }

    [MinLength(1)]
    [MaxLength(256)]
    public string Name { get; set; } = default!;

    [MinLength(1)]
    [MaxLength(256)]
    public string Location { get; set; } = default!;

    public DateTime From { get; set; }
    public DateTime Until { get; set; }

    public ICollection<AppUserAtConcert>? AppUserAtConcerts { get; set; }
    public ICollection<JuryMember>? JuryMembers { get; set; }
}