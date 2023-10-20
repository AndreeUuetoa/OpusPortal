using Domain.Competitions;
using Domain.Concerts;
using Domain.Identity;
using Domain.Library;
using Domain.Studying_logic;
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
    public DbSet<Institution> Institution { get; set; } = default!;
    
    // Library
    public DbSet<Book> Book { get; set; } = default!;
    public DbSet<BookLentOut> BookLentOut { get; set; } = default!;
    
    // Studying logic
    // public DbSet<Class> Class { get; set; } = default!;
    // public DbSet<ClassInRoom> ClassInRoom { get; set; } = default!;
    // public DbSet<Curriculum> Curriculum { get; set; } = default!;
    // public DbSet<PersonOnCurriculum> PersonOnCurriculum { get; set; } = default!;
    // public DbSet<Room> Room { get; set; } = default!;
    // public DbSet<Subject> Subject { get; set; } = default!;
    // public DbSet<PersonOnSubject> PersonSubject { get; set; } = default!;
    // public DbSet<SubjectInCurriculum> SubjectInCurriculum { get; set; } = default!;
    // public DbSet<SubjectTeacher> SubjectTeacher { get; set; } = default!;
    // public DbSet<TeacherInClass> TeacherInClass { get; set; } = default!;

    // Identity
    public DbSet<AppRole> AppRole { get; set; } = default!;
    public DbSet<AppUser> AppUser { get; set; } = default!;
    public DbSet<MajorTeacher> MajorTeachers { get; set; } = default!;
    public DbSet<RefreshToken> AppRefreshTokens { get; set; } = default!;

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}

    protected override void OnModelCreating(ModelBuilder builder)
    {
        // let the initial stuff run
        base.OnModelCreating(builder);
        
        // disable cascade delete
        foreach (var foreignKey in builder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
        {
            foreignKey.DeleteBehavior = DeleteBehavior.Restrict;
        }
    }
}