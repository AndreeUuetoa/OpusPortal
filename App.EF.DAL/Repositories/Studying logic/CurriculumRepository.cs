using App.DAL.Contracts.Repositories;
using App.DAL.Contracts.Repositories.Studying_logic;
using Base;
using Domain.Studying_logic;

namespace DAL.Repositories.Studying_logic;

public class CurriculumRepository : EFBaseRepository<Curriculum, AppDbContext>,
    ICurriculumRepository
{
    public CurriculumRepository(AppDbContext dbContext) : base(dbContext)
    {
    }
}