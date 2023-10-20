using App.DAL.Contracts.Repositories;
using App.DAL.Contracts.Repositories.Institutions;
using Base;
using Domain.Competitions;

namespace DAL.Repositories.Institutions;

public class InstitutionRepository : EFBaseRepository<Institution, AppDbContext>, IInstitutionRepository
{
    public InstitutionRepository(AppDbContext dbContext) : base(dbContext)
    {
    }
}