using Base.DAL.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Base;

public abstract class EFBaseUOW<TDbContext> : IBaseUOW
    where TDbContext : DbContext
{
    protected readonly TDbContext UowDbContext;

    protected EFBaseUOW(TDbContext context)
    {
        UowDbContext = context;
    }
    
    public virtual async Task<int> SaveChanges()
    {
        return await UowDbContext.SaveChangesAsync();
    }
}
