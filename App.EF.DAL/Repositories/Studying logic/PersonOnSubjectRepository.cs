using App.DAL.Contracts.Repositories;
using App.DAL.Contracts.Repositories.Studying_logic;
using Base;
using Domain.Studying_logic;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories.Studying_logic;

public class PersonOnSubjectRepository : EFBaseRepository<AppUserOnSubject, AppDbContext>,
    IPersonOnSubjectRepository
{
    public PersonOnSubjectRepository(AppDbContext dbContext) : base(dbContext)
    {
    }

    public override async Task<IEnumerable<AppUserOnSubject>> All()
    {
        return await RepositoryDbSet
            .Include(s => s.SubjectInCurriculum)
            .Include(s => s.AppUserOnCurriculum)
            .ToListAsync();
    }

    public async Task<IEnumerable<AppUserOnSubject>> AllWithUserId(Guid id)
    {
        return await RepositoryDbSet
            .Include(s => s.SubjectInCurriculum)
            .Include(s => s.AppUserOnCurriculum)
            .Where(s => s.AppUserOnCurriculumId.Equals(id))
            .ToListAsync();
    }

    public override async Task<AppUserOnSubject?> Find(Guid id)
    {
        return await RepositoryDbSet
            .Include(s => s.SubjectInCurriculum)
            .Include(s => s.AppUserOnCurriculum)
            .FirstOrDefaultAsync(m => m.Id == id);
    }
}