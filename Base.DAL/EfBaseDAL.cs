using Base.DAL.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Base;

public abstract class EfBaseDAL<TDbContext> : IBaseDAL
    where TDbContext : DbContext
{
    protected readonly TDbContext UowDbContext;

    protected EfBaseDAL(TDbContext context)
    {
        UowDbContext = context;
    }
    
    public virtual async Task<int> SaveChanges()
    {
        return await UowDbContext.SaveChangesAsync();
    }
}
