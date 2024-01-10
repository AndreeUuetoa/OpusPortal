using Base.Domain.Contracts;
using Domain.Concerts;
using Domain.Library;
using Microsoft.AspNetCore.Identity;

namespace Domain.Identity;

public class AppUser : IdentityUser<Guid>, IDomainEntityId
{
    public Guid AppRoleId { get; set; }
    public AppRole? AppRole { get; set; }

    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;

    public DateTime From { get; set; }
    public DateTime? Until { get; set; }

    public ICollection<BookLentOut>? BooksLentOut { get; set; }
    public ICollection<AppUserAtConcert>? AppUserAtConcerts { get; set; }
    public ICollection<UserTeachingUser>? UserTeachingUsers { get; set; }

    public ICollection<RefreshToken>? AppRefreshTokens { get; set; } 
}