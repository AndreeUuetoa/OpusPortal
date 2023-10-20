using App.BLL.Contracts.Services.Institutions;
using App.DAL.Contracts;
using App.DAL.Contracts.Repositories.Institutions;
using Base;
using Base.BLL;
using DomainInstitution = Domain.Competitions.Institution;
using BLLInstitution = BLL.DTO.Institutions.Institution;

namespace App.BLL.Services.Institutions;

public class InstitutionService : BaseEntityService<DomainInstitution, BLLInstitution, IInstitutionRepository>, IInstitutionService
{
    private readonly IAppUOW _uow;
    
    public InstitutionService(IAppUOW uow, IMapper<DomainInstitution, BLLInstitution> mapper) : base(uow.InstitutionRepository, mapper)
    {
        _uow = uow;
    }
}