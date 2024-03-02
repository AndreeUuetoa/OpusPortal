using App.BLL.Contracts.Services.Competitions;
using App.DAL.Contracts;
using App.DAL.Contracts.Repositories.Competitions;
using Base;
using Base.BLL;
using DomainCompetition = Domain.Competitions.Competition;
using BLLCompetition = BLL.DTO.Competitions.Competition;

namespace App.BLL.Services.Competitions;

public class CompetitionService : BaseEntityService<DomainCompetition, BLLCompetition, ICompetitionRepository>, ICompetitionService
{
    private readonly IAppDAL _dal;
    
    public CompetitionService(IAppDAL dal, IMapper<DomainCompetition, BLLCompetition> mapper) : base(dal.CompetitionRepository, mapper)
    {
        _dal = dal;
    }
}