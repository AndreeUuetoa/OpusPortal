using System.ComponentModel.DataAnnotations;
using Base.Domain;
using Domain.Concerts;

namespace Domain.Competitions;

public class Institution : DomainEntityId
{
    [MinLength(1)]
    [MaxLength(256)]
    public string Name { get; set; } = default!;

    [MinLength(1)]
    [MaxLength(256)]
    public string Address { get; set; } = default!;
    
    public ICollection<Concert>? Concerts { get; set; }
}