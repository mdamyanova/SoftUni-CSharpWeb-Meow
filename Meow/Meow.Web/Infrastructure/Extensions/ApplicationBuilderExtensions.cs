namespace Meow.Web.Infrastructure.Extensions
{
    using Data;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;

    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseDatabaseMigration(this IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                serviceScope.ServiceProvider.GetService<MeowDbContext>().Database.Migrate();

                //var userManager = serviceScope.ServiceProvider.GetService<UserManager<User>>();
                //var roleManager = serviceScope.ServiceProvider.GetService<RoleManager<IdentityRole>>();

                //Task
                //    .Run(async () =>
                //    {
                //        var adminName = WebConstants.AdministratorRole;
                //        var roles = new[]
                //        {
                //            adminName,
                //            WebConstants.BlogAuthorRole,
                //            WebConstants.TrainerRole
                //        };

                //        foreach (var role in roles)
                //        {

                //            var roleExists = await roleManager.RoleExistsAsync(role);

                //            if (!roleExists)
                //            {
                //                await roleManager.CreateAsync(new IdentityRole
                //                {
                //                    Name = role
                //                });
                //            }
                //        }

                //        var adminEmail = "admin@mysite.com";
                //        var adminUser = await userManager.FindByEmailAsync(adminEmail);
                        
                //        if (adminUser == null)
                //        {
                //            adminUser = new User
                //            {
                //                Email = adminEmail,
                //                UserName = adminName,
                //                Name = adminName,
                //                Birthdate = DateTime.UtcNow
                //            };

                //            await userManager.CreateAsync(adminUser, "admin11");
                //            await userManager.AddToRoleAsync(adminUser, adminName);
                //        }
                //    })
                //    .Wait();
            }
        
            return app;
        }
    }
}