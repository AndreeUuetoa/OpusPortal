using Base.DAL.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Base;

public abstract class EfBaseDAL<TDbContext> : IBaseDAL
    where TDbContext : DbContext
{
    protected readonly TDbContext DALDbContext;

    protected EfBaseDAL(TDbContext context)
    {
        DALDbContext = context;
    }
    
    public virtual async Task<int> SaveChanges()
    {
        return await DALDbContext.SaveChangesAsync();
    }
}
