using Domain.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace DAL.Seeding;

public static class AppDataInit
{
    public static async Task MigrateDatabase(AppDbContext context)
    {
        await context.Database.MigrateAsync();
    }

    public static async Task SeedIdentity(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager, AppDbContext context)
    {
        await CreateRoles(roleManager);
        await CreateAdmin(userManager, roleManager);
        await context.SaveChangesAsync();
    }

    private static async Task CreateRoles(RoleManager<AppRole> roleManager)
    {
        var roles = new[]
        {
            "Student",
            "Teacher",
            "Admin",
            "Other"
        };
        foreach (var roleName in roles)
        {
            var existingRole = await roleManager.FindByNameAsync(roleName);
            if (existingRole != null)
            {
                continue;
            }
            var identityResult = await roleManager.CreateAsync(new AppRole
            {
                Name = roleName
            });
            if (!identityResult.Succeeded)
            {
                throw new ApplicationException("Role creation failed");
            }
        }
    }

    private static async Task CreateAdmin(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
    {
        (Guid id, string email, string userName, string password) userData = (Guid.NewGuid(), "admin@opusportal.com", "Admin", "Foo.bar1");
        var user = await userManager.FindByEmailAsync(userData.email);
        if (user != null) return;
        
        var adminRole = await roleManager.FindByNameAsync("Admin");
        if (adminRole == null)
        {
            throw new ApplicationException("Admin role has not been created.");
        }
        
        user = new AppUser
        {
            Id = userData.id,
            UserName = userData.userName,
            Email = userData.email,
            EmailConfirmed = true,
            FirstName = userData.userName,
            LastName = "",
            AppRoleId = adminRole.Id,
            AppRole = adminRole,
            From = DateTime.UtcNow
        };
        var result = await userManager.CreateAsync(user, userData.password);
        if (!result.Succeeded)
        {
            foreach (var identityError in result.Errors)
            {
                Console.WriteLine(identityError.Description);
            }
            throw new ApplicationException("Cannot seed admin user.");
        }
    }
}
