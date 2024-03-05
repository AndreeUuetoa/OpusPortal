using App.DAL.Contracts;
using App.DAL.Contracts.Repositories.Competitions;
using App.DAL.Contracts.Repositories.Concerts;
using App.DAL.Contracts.Repositories.Identity;
using App.DAL.Contracts.Repositories.Library;
using App.DAL.Contracts.Repositories.Rooms;
using Base;
using DAL.Repositories.Competitions;
using DAL.Repositories.Concerts;
using DAL.Repositories.Identity;
using DAL.Repositories.Library;
using DAL.Repositories.Rooms;

namespace DAL;

public class AppDAL : EfBaseDAL<AppDbContext>, IAppDAL
{
    private IAppRoleRepository? _appRoleRepository;
    private IAppUserRepository? _appUserRepository;
    private IBookRepository? _bookRepository;
    private ICompetitionRepository? _competitionRepository;
    private IConcertRepository? _concertRepository;
    private IBookLentOutRepository? _libraryRepository;
    private IAppUserAtConcertRepository? _performanceRepository;
    private IJuryMemberRepository? _juryMemberRepository;
    private IAppUserInRoomRepository? _appUserInRoomRepository;
    private IRoomRepository? _roomRepository;

    public IAppRoleRepository AppRoleRepository => _appRoleRepository ??= new AppRoleRepository(DALDbContext);
    public IAppUserRepository AppUserRepository => _appUserRepository ??= new AppUserRepository(DALDbContext);
    public IBookRepository BookRepository => _bookRepository ??= new BookRepository(DALDbContext);
    public ICompetitionRepository CompetitionRepository => _competitionRepository ??= new CompetitionRepository(DALDbContext);
    public IConcertRepository ConcertRepository => _concertRepository ??= new ConcertRepository(DALDbContext);
    public IBookLentOutRepository BookLentOutRepository => _libraryRepository ??= new BookLentOutRepository(DALDbContext);
    public IAppUserAtConcertRepository AppUserAtConcertRepository => _performanceRepository ??= new AppUserAtConcertRepository(DALDbContext);
    public IJuryMemberRepository JuryMemberRepository => _juryMemberRepository ??= new JuryMemberRepository(DALDbContext);
    public IRoomRepository RoomRepository => _roomRepository ??= new RoomRepository(DALDbContext);

    public IAppUserInRoomRepository AppUserInRoomRepository => _appUserInRoomRepository ??= new AppUserInRoomRepository(DALDbContext);

    public AppDAL(AppDbContext context) : base(context)
    {
    }
}
