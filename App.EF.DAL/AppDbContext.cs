using Domain.Competitions;
using Domain.Concerts;
using Domain.Identity;
using Domain.Library;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DAL;

public class AppDbContext : IdentityDbContext<AppUser, AppRole, Guid>
{
    // Concerts & competitions
    public DbSet<Competition> Competition { get; set; } = default!;
    public DbSet<JuryMember> JuryMember { get; set; } = default!;
    
    public DbSet<Concert> Concert { get; set; } = default!;
    public DbSet<AppUserAtConcert> AppUserAtConcert { get; set; } = default!;
    
    // Library
    public DbSet<Book> Book { get; set; } = default!;
    public DbSet<BookLentOut> BookLentOut { get; set; } = default!;
    
    // Identity
    public DbSet<AppRole> AppRole { get; set; } = default!;
    public DbSet<AppUser> AppUser { get; set; } = default!;
    public DbSet<UserTeachingUser> UserTeachingUsers { get; set; } = default!;
    public DbSet<RefreshToken> AppRefreshTokens { get; set; } = default!;

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}

    protected override void OnModelCreating(ModelBuilder builder)
    {
        // let the initial stuff run
        base.OnModelCreating(builder);

        builder.Entity<AppUser>().HasMany(appUser => appUser.UserTeachingUsers);
        builder.Entity<UserTeachingUser>().HasOne(userTeachingUser => userTeachingUser.Student);
        builder.Entity<UserTeachingUser>().HasOne(userTeachingUser => userTeachingUser.Teacher);
        
        // disable cascade delete
        foreach (var foreignKey in builder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
        {
            foreignKey.DeleteBehavior = DeleteBehavior.Restrict;
        }
    }
}
