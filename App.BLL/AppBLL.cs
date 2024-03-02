using App.BLL.Contracts;
using App.BLL.Contracts.Services.Competitions;
using App.BLL.Contracts.Services.Concerts;
using App.BLL.Contracts.Services.Identity;
using App.BLL.Contracts.Services.Library;
using App.BLL.Contracts.Services.Rooms;
using App.BLL.Mappers.Competitions;
using App.BLL.Mappers.Concerts;
using App.BLL.Mappers.Identity;
using App.BLL.Mappers.Library;
using App.BLL.Mappers.Rooms;
using App.BLL.Services.Competitions;
using App.BLL.Services.Concerts;
using App.BLL.Services.Identity;
using App.BLL.Services.Library;
using App.BLL.Services.Rooms;
using App.DAL.Contracts;
using AutoMapper;
using Base.BLL;

namespace App.BLL;

public class AppBLL : BaseBLL<IAppDAL>, IAppBLL
{
    private readonly IMapper _mapper;

    private IAppUserService? _appUserService;
    private IAppRoleService? _appRoleService;
    
    private IBookService? _bookService;
    private IBookLentOutService? _bookLentOutService;

    private IAppUserAtConcertService? _appUserAtConcertService;
    private IConcertService? _concertService;

    private ICompetitionService? _competitionService;
    private IJuryService? _juryService;

    private IAppUserInRoomService? _appUserInRoomService;
    private IRoomService? _roomService;

    public AppBLL(IAppDAL dal, IMapper mapper) : base(dal)
    {
        _mapper = mapper;
    }

    public IAppUserService AppUserService => _appUserService ??= new AppUserService(Dal, new AppUserMapper(_mapper));
    public IAppRoleService AppRoleService => _appRoleService ??= new AppRoleService(Dal, new AppRoleMapper(_mapper));
    public IBookService BookService => _bookService ??= new BookService(Dal, new BookMapper(_mapper));
    public IBookLentOutService BookLentOutService => _bookLentOutService ??= new BookLentOutService(Dal, new BookLentOutMapper(_mapper));

    public IAppUserAtConcertService AppUserAtConcertService => _appUserAtConcertService ??= new AppUserAtConcertService(Dal, new AppUserAtConcertMapper(_mapper));
    public IConcertService ConcertService => _concertService ??= new ConcertService(Dal, new ConcertMapper(_mapper));
    
    public ICompetitionService CompetitionService => _competitionService ??= new CompetitionService(Dal, new CompetitionMapper(_mapper));
    public IJuryService JuryService => _juryService ??= new JuryService(Dal, new JuryMemberMapper(_mapper));

    public IAppUserInRoomService AppUserInRoomService => _appUserInRoomService ??= new AppUserInRoomService(Dal, new AppUserInRoomMapper(_mapper));
    public IRoomService RoomService => _roomService ??= new RoomService(Dal, new RoomMapper(_mapper));
}