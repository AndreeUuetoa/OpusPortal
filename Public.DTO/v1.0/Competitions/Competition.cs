using Base.DTO;
using Public.DTO.v1._0.Concerts;

namespace Public.DTO.v1._0.Competitions;

public class Competition : DTOEntityId
{
    public string Name { get; set; } = default!;

    public ICollection<Concert>? Concerts { get; set; }
}