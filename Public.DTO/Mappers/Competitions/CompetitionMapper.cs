using AutoMapper;
using Base.Mappers;

namespace Public.DTO.Mappers.Competitions;

public class CompetitionMapper : BaseMapper<BLL.DTO.Competitions.Competition, DTO.v1._0.Competitions.Competition>
{
    public CompetitionMapper(IMapper mapper) : base(mapper)
    {
    }
}