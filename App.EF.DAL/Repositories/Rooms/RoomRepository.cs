using App.DAL.Contracts.Repositories.Rooms;
using Base;
using Domain.Rooms;

namespace DAL.Repositories.Rooms;

public class RoomRepository : EFBaseRepository<Room, AppDbContext>, IRoomRepository
{
    public RoomRepository(AppDbContext dbContext) : base(dbContext)
    {
    }
}