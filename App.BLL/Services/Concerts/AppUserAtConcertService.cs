using App.BLL.Contracts.Services.Concerts;
using App.DAL.Contracts;
using App.DAL.Contracts.Repositories.Concerts;
using Base;
using Base.BLL;
using DomainAppUserAtConcert = Domain.Concerts.AppUserAtConcert;
using BLLAppUserAtConcert = BLL.DTO.Concerts.AppUserAtConcert;

namespace App.BLL.Services.Concerts;

public class AppUserAtConcertService : BaseEntityService<DomainAppUserAtConcert, BLLAppUserAtConcert, IAppUserAtConcertRepository>, IAppUserAtConcertService
{
    private readonly IAppUOW _uow;
    
    public AppUserAtConcertService(IAppUOW uow, IMapper<DomainAppUserAtConcert, BLLAppUserAtConcert> mapper) : base(uow.AppUserAtConcertRepository, mapper)
    {
        _uow = uow;
    }
    
    public async Task<IEnumerable<BLLAppUserAtConcert>> AllWithUserId(Guid id)
    {
        return (await _uow.AppUserAtConcertRepository.AllWithUserId(id)).Select(e => Mapper.Map(e));
    }
}