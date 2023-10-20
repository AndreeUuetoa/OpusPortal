using App.DAL.Contracts;
using App.DAL.Contracts.Repositories.Competitions;
using App.DAL.Contracts.Repositories.Concerts;
using App.DAL.Contracts.Repositories.Identity;
using App.DAL.Contracts.Repositories.Institutions;
using App.DAL.Contracts.Repositories.Library;
using Base;
using DAL.Repositories.Competitions;
using DAL.Repositories.Concerts;
using DAL.Repositories.Identity;
using DAL.Repositories.Institutions;
using DAL.Repositories.Library;

namespace DAL.UnitOfWork;

public class AppUOW : EFBaseUOW<AppDbContext>, IAppUOW
{
    private IAppRoleRepository? _appRoleRepository;
    private IAppUserRepository? _appUserRepository;
    private IBookRepository? _bookRepository;
    private ICompetitionRepository? _competitionRepository;
    private IConcertRepository? _concertRepository;
    private IBookLentOutRepository? _libraryRepository;
    private IAppUserAtConcertRepository? _performanceRepository;
    private IInstitutionRepository? _institutionRepository;
    private IJuryMemberRepository? _juryMemberRepository;

    public IAppRoleRepository AppRoleRepository => _appRoleRepository ??= new AppRoleRepository(UowDbContext);
    public IAppUserRepository AppUserRepository => _appUserRepository ??= new AppUserRepository(UowDbContext);
    public IBookRepository BookRepository => _bookRepository ??= new BookRepository(UowDbContext);
    public ICompetitionRepository CompetitionRepository => _competitionRepository ??= new CompetitionRepository(UowDbContext);
    public IConcertRepository ConcertRepository => _concertRepository ??= new ConcertRepository(UowDbContext);
    public IInstitutionRepository InstitutionRepository => _institutionRepository ??= new InstitutionRepository(UowDbContext);
    public IBookLentOutRepository BookLentOutRepository => _libraryRepository ??= new BookLentOutRepository(UowDbContext);
    public IAppUserAtConcertRepository AppUserAtConcertRepository => _performanceRepository ??= new AppUserAtConcertRepository(UowDbContext);
    public IJuryMemberRepository JuryMemberRepository => _juryMemberRepository ??= new JuryMemberRepository(UowDbContext);

    public AppUOW(AppDbContext context) : base(context)
    {
    }
}