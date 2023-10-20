using AutoMapper;
using Base.Mappers;
using BLLAppUserAtConcert = BLL.DTO.Concerts.AppUserAtConcert;
using DomainAppUserAtConcert = Domain.Concerts.AppUserAtConcert;

namespace App.BLL.Mappers.Concerts;

public class AppUserAtConcertMapper : BaseMapper<DomainAppUserAtConcert, BLLAppUserAtConcert>
{
    public AppUserAtConcertMapper(IMapper mapper) : base(mapper)
    {
    }
}