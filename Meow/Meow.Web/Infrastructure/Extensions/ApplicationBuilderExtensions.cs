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
    using System.Globalization;
    using System.IO;
    using System.Net;
    using System.Threading.Tasks;

    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseDatabaseMigration(this IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
               //serviceScope.ServiceProvider.GetService<MeowDbContext>().Database.Migrate();

                var userManager = serviceScope.ServiceProvider.GetService<UserManager<User>>();
                var roleManager = serviceScope.ServiceProvider.GetService<RoleManager<IdentityRole>>();

                Task
                    .Run(async () =>
                    {
                        var adminName = WebConstants.AdministratorRole;
                        var volunteerName = WebConstants.VolunteerRole;

                        var defaultBirthdate = "08/08/1990";
                        var defaultProfilePhoto = WebConstants.DefaultProfilePhotoPath;

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

                        var web = new WebClient();

                        if (adminUser == null)
                        {
                            adminUser = new User
                            {
                                Email = adminEmail,
                                UserName = adminName,
                                Name = adminName,
                                Gender = Gender.Female,
                                Birthdate = DateTime.ParseExact(defaultBirthdate, "MM/dd/yyyy", CultureInfo.CreateSpecificCulture("en-US")),
                                Location = "Sofia",
                                ProfilePhoto = web.DownloadData(defaultProfilePhoto)
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
                                Birthdate = DateTime.ParseExact(defaultBirthdate, "MM/dd/yyyy", CultureInfo.CreateSpecificCulture("en-US")),
                                Location = "Sofia",
                                ProfilePhoto = web.DownloadData(defaultProfilePhoto)
                            };

                            var result = await userManager.CreateAsync(volunteerUser, "icatrescue1");

                            await userManager.AddToRoleAsync(volunteerUser, volunteerName);
                        }

                        // how narcissistic

                        var mirelkaEmail = "mdamyanova181@gmail.com";
                        var mirelkaUser = await userManager.FindByEmailAsync(mirelkaEmail);
                        var mirelkaBirthdate = "07/25/1995";

                        if (mirelkaUser == null)
                        {
                            mirelkaUser = new User
                            {
                                Email = mirelkaEmail,
                                UserName = "mirelka",
                                Name = "Mirelka",
                                Gender = Gender.Female,
                                Birthdate = DateTime.ParseExact(mirelkaBirthdate, "MM/dd/yyyy", CultureInfo.CreateSpecificCulture("en-US")),
                                Location = "Sofia",
                                ProfilePhoto = web.DownloadData(WebConstants.DefaultMirelkaProfilePhotoPath)
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
