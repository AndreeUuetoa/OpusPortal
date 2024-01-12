using DAL;
using Domain.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Tests;

public class CustomWebAppFactory<TStartup> : WebApplicationFactory<TStartup> 
    where TStartup : class
{
    private static bool isDbInitialized;

    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        base.ConfigureWebHost(builder);

        builder.ConfigureServices(services =>
        {
            // find DbContext
            var descriptor = services.SingleOrDefault(
                d => d.ServiceType ==
                     typeof(DbContextOptions<AppDbContext>));

            // if found - remove
            if (descriptor != null)
            {
                services.Remove(descriptor);
            }

            // and new DbContext
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseInMemoryDatabase("InMemoryDbForTesting");
            });

            // create db and seed data
            var sp = services.BuildServiceProvider();
            using var scope = sp.CreateScope();
            var scopedServices = scope.ServiceProvider;
            var db = scopedServices.GetRequiredService<AppDbContext>();
            var logger = scopedServices
                .GetRequiredService<ILogger<CustomWebAppFactory<TStartup>>>();

            db.Database.EnsureCreated();

            try
            {
                if (isDbInitialized) return;
                isDbInitialized = true;
                var adminRole = new AppRole
                {
                    Name = "Admin"
                };
                var addedAdminRole = db.AppRole.Add(adminRole).Entity;
                var studentRole = new AppRole
                {
                    Name = "Student"
                };
                db.AppRole.Add(studentRole);
                var teacherRole = new AppRole
                {
                    Name = "Teacher"
                };
                db.AppRole.Add(teacherRole);
                var adminUser = new AppUser
                {
                    AppRoleId = addedAdminRole.Id,
                    Email = "admin@opusportal.com",
                    FirstName = "Admin",
                    LastName = "Admin",
                    From = DateTime.UtcNow
                };
                db.AppUser.Add(adminUser);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "An error occurred seeding the database with test data.");
            }
        });
    }
}