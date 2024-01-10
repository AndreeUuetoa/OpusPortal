using Base.DTO;
using BLL.DTO.Concerts;

namespace BLL.DTO.Competitions;

public class Competition : DTOEntityId
{
    public string Name { get; set; } = default!;

    public ICollection<Concert>? Concerts { get; set; }
}