using App.BLL.Contracts.Services.Competitions;
using App.BLL.Contracts.Services.Concerts;
using App.BLL.Contracts.Services.Identity;
using App.BLL.Contracts.Services.Library;
using App.BLL.Contracts.Services.Rooms;
using Base.BLL.Contracts;

namespace App.BLL.Contracts;

public interface IAppBLL : IBaseBLL
{
    IAppUserService AppUserService { get; }
    IAppRoleService AppRoleService { get; }
        
    IBookService BookService { get; }
    IBookLentOutService BookLentOutService { get; }
    
    IAppUserAtConcertService AppUserAtConcertService { get; }
    IConcertService ConcertService { get; }
    
    ICompetitionService CompetitionService { get; }
    IJuryService JuryService { get; }
    
    IAppUserInRoomService AppUserInRoomService { get; }
    IRoomService RoomService { get; }
}