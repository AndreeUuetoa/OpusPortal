using AutoMapper;
using Base.Mappers;
using BLLAppUserAtConcert = BLL.DTO.Concerts.AppUserAtConcert;
using PublicAppUserAtConcert = Public.DTO.v1._0.Concerts.AppUserAtConcert;

namespace Public.DTO.Mappers.Concerts;

public class AppUserAtConcertMapper : BaseMapper<BLLAppUserAtConcert, PublicAppUserAtConcert>
{
    public AppUserAtConcertMapper(IMapper mapper) : base(mapper)
    {
    }
}