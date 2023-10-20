using App.BLL.Contracts;
using App.BLL.Contracts.Services.Competitions;
using App.BLL.Contracts.Services.Concerts;
using App.BLL.Contracts.Services.Identity;
using App.BLL.Contracts.Services.Institutions;
using App.BLL.Contracts.Services.Library;
using App.BLL.Mappers.Competitions;
using App.BLL.Mappers.Concerts;
using App.BLL.Mappers.Identity;
using App.BLL.Mappers.Institutions;
using App.BLL.Mappers.Library;
using App.BLL.Services.Competitions;
using App.BLL.Services.Concerts;
using App.BLL.Services.Identity;
using App.BLL.Services.Institutions;
using App.BLL.Services.Library;
using App.DAL.Contracts;
using AutoMapper;
using Base.BLL;

namespace App.BLL;

public class AppBLL : BaseBLL<IAppUOW>, IAppBLL
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

    private IInstitutionService? _institutionService;
    
    public AppBLL(IAppUOW uow, IMapper mapper) : base(uow)
    {
        _mapper = mapper;
    }

    public IAppUserService AppUserService => _appUserService ??= new AppUserService(Uow, new AppUserMapper(_mapper));
    public IAppRoleService AppRoleService => _appRoleService ??= new AppRoleService(Uow, new AppRoleMapper(_mapper));
    public IBookService BookService => _bookService ??= new BookService(Uow, new BookMapper(_mapper));
    public IBookLentOutService BookLentOutService => _bookLentOutService ??= new BookLentOutService(Uow, new BookLentOutMapper(_mapper));

    public IAppUserAtConcertService AppUserAtConcertService => _appUserAtConcertService ??= new AppUserAtConcertService(Uow, new AppUserAtConcertMapper(_mapper));
    public IConcertService ConcertService => _concertService ??= new ConcertService(Uow, new ConcertMapper(_mapper));
    
    public ICompetitionService CompetitionService => _competitionService ??= new CompetitionService(Uow, new CompetitionMapper(_mapper));
    public IJuryService JuryService => _juryService ??= new JuryService(Uow, new JuryMemberMapper(_mapper));

    public IInstitutionService InstitutionService => _institutionService ??= new InstitutionService(Uow, new InstitutionMapper(_mapper));
}