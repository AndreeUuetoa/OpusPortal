using App.DAL.Contracts.Repositories.Competitions;
using App.DAL.Contracts.Repositories.Concerts;
using App.DAL.Contracts.Repositories.Identity;
using App.DAL.Contracts.Repositories.Library;
using App.DAL.Contracts.Repositories.Rooms;
using Base.DAL.Contracts;

namespace App.DAL.Contracts;

public interface IAppUOW : IBaseUOW
{
    public IAppRoleRepository AppRoleRepository { get; }
    public IAppUserRepository AppUserRepository { get; }
    public IBookRepository BookRepository { get; }
    public ICompetitionRepository CompetitionRepository { get; }
    public IConcertRepository ConcertRepository { get; }
    public IBookLentOutRepository BookLentOutRepository { get; }
    public IAppUserAtConcertRepository AppUserAtConcertRepository { get; }
    public IJuryMemberRepository JuryMemberRepository { get; }
    public IRoomRepository RoomRepository { get; }
    public IAppUserInRoomRepository AppUserInRoomRepository { get; }
}