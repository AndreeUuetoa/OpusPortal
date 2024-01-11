using Base.DTO;

namespace Public.DTO.v1._0.Concerts;

public class Concert : DTOEntityId
{
    public Guid? CompetitionId { get; set; }
    
    public string Name { get; set; } = default!;
    public string Location { get; set; } = default!;

    public DateTime From { get; set; }
}