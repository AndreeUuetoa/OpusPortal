using Base.BLL.Contracts;
using BLL.DTO.Identity;
using AppUserAtConcert = BLL.DTO.Concerts.AppUserAtConcert;

namespace App.BLL.Contracts.Services.Concerts;

public interface IAppUserAtConcertService : IBaseEntityService<AppUserAtConcert>
{
    
}