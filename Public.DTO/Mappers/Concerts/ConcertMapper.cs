using AutoMapper;
using Base.Mappers;
using BLLConcert = BLL.DTO.Concerts.Concert;
using PublicConcert = Public.DTO.v1._0.Concerts.Concert;

namespace Public.DTO.Mappers.Concerts;

public class ConcertMapper : BaseMapper<BLLConcert, PublicConcert>
{
    public ConcertMapper(IMapper mapper) : base(mapper)
    {
    }
}