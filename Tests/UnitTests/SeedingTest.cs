using DAL;
using DAL.Seeding;
using Microsoft.EntityFrameworkCore;

namespace Tests.UnitTests;

public class SeedingTest : IDisposable
{
    private readonly AppDbContext _ctx;
    
    public SeedingTest()
    {
        // set up mock database - in-memory
        var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();

        // use random guid as db instance id
        optionsBuilder.UseInMemoryDatabase(Guid.NewGuid().ToString());
        _ctx = new AppDbContext(optionsBuilder.Options);

        // reset db
        _ctx.Database.EnsureDeleted();
        _ctx.Database.EnsureCreated();
    }

    [Fact]
    public void TestSeedIdentity()
    {
        
    }
    
    public void Dispose()
    {
        _ctx.Dispose();
        GC.SuppressFinalize(this);
    }
}