using App.DAL.Contracts.Repositories.Rooms;
using Base;
using Domain.Rooms;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories.Rooms;

public class AppUserInRoomRepository : EFBaseRepository<AppUserInRoom, AppDbContext>, IAppUserInRoomRepository
{
    public AppUserInRoomRepository(AppDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<IEnumerable<AppUserInRoom>> AllWithUserId(Guid id)
    {
        return await RepositoryDbSet
            .Include(i => i.Room)
            .Include(i => i.AppUser)
            .Where(appUser => appUser.AppUserId == id)
            .ToListAsync();
    }
}