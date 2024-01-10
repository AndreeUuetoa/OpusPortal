using System.ComponentModel.DataAnnotations;
using Base.DTO;

namespace BLL.DTO.Concerts;

public class Concert : DTOEntityId
{
    [MinLength(1)]
    [MaxLength(256)]
    public string Name { get; set; } = default!;
    
    [MinLength(1)]
    [MaxLength(256)]
    public string Location { get; set; } = default!;

    public DateTime From { get; set; }
    public DateTime Until { get; set; }
}