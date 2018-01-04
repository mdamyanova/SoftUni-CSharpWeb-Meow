namespace Meow.Web.Infrastructure.Extensions
{
    using Core;
    using Data;
    using Data.Models;
    using Data.Models.Enums;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using System;
    using System.IO;
    using System.Threading.Tasks;

    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseDatabaseMigration(this IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                serviceScope.ServiceProvider.GetService<MeowDbContext>().Database.Migrate();

                var userManager = serviceScope.ServiceProvider.GetService<UserManager<User>>();
                var roleManager = serviceScope.ServiceProvider.GetService<RoleManager<IdentityRole>>();

                Task
                    .Run(async () =>
                    {
                        var adminName = WebConstants.AdministratorRole;
                        var volunteerName = WebConstants.VolunteerRole;

                        var defaultProfilePhoto = File.ReadAllBytes("../Meow.Web/wwwroot/images/default-cat.png");

                        // admin, volunteer, normal user
                        var roles = new[]
                        {
                            adminName,
                            volunteerName
                        };

                        foreach (var role in roles)
                        {
                            var roleExists = await roleManager.RoleExistsAsync(role);

                            if (!roleExists)
                            {
                                await roleManager.CreateAsync(new IdentityRole
                                {
                                    Name = role
                                });
                            }
                        }

                        var adminEmail = "admin@mysite.com";
                        var adminUser = await userManager.FindByEmailAsync(adminEmail);

                        if (adminUser == null)
                        {
                            adminUser = new User
                            {
                                Email = adminEmail,
                                UserName = adminName,
                                Name = adminName,
                                Gender = Gender.Female,
                                Birthdate = DateTime.UtcNow,
                                Location = "Sofia",
                                ProfilePhoto = defaultProfilePhoto
                            };

                            var result = await userManager.CreateAsync(adminUser, "admin11");

                            await userManager.AddToRoleAsync(adminUser, adminName);
                            await userManager.AddToRoleAsync(adminUser, volunteerName);
                        }

                        var volunteerEmail = "contact@icatrescue.com";
                        var volunteerUser = await userManager.FindByEmailAsync(volunteerEmail);

                        if (volunteerUser == null)
                        {
                            volunteerUser = new User
                            {
                                Email = volunteerEmail,
                                UserName = volunteerName,
                                Name = volunteerName,
                                Gender = Gender.Male,
                                Birthdate = DateTime.UtcNow,
                                Location = "Sofia",
                                ProfilePhoto = defaultProfilePhoto
                            };

                            var result = await userManager.CreateAsync(volunteerUser, "icatrescue1");

                            await userManager.AddToRoleAsync(volunteerUser, volunteerName);
                        }

                        // how narcissistic

                        var mirelkaEmail = "mdamyanova181@gmail.com";
                        var mirelkaUser = await userManager.FindByEmailAsync(mirelkaEmail);

                        if (mirelkaUser == null)
                        {
                            mirelkaUser = new User
                            {
                                Email = mirelkaEmail,
                                UserName = "mirelka",
                                Name = "Mirelka",
                                Gender = Gender.Female,
                                Birthdate = DateTime.Parse("25/07/1995"),
                                Location = "Sofia",
                                ProfilePhoto = File.ReadAllBytes("../Meow.Web/wwwroot/images/mirelka/mirelka-profile.jpg")
                            };

                            var result = await userManager.CreateAsync(mirelkaUser, "mirelka1");
                        }
                    })
                    .Wait();
            }
       
            return app;
        }
    }
}