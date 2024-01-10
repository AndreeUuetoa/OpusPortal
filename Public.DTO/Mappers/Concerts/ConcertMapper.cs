using AutoMapper;
using Base.Mappers;

namespace Public.DTO.Mappers.Concerts;

public class ConcertMapper : BaseMapper<BLL.DTO.Concerts.Concert, DTO.v1._0.Concerts.Concert>
{
    public ConcertMapper(IMapper mapper) : base(mapper)
    {
    }
}