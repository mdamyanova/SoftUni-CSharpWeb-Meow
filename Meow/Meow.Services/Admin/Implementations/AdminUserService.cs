namespace Meow.Services.Admin.Implementations
{
    using AutoMapper.QueryableExtensions;
    using Contracts;
    using Data;
    using Microsoft.EntityFrameworkCore;
    using Services.Admin.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class AdminUserService : IAdminUserService
    {
        private readonly MeowDbContext db;

        public AdminUserService(MeowDbContext db)
        {
            this.db = db;
        }

        public async Task<IEnumerable<AdminUsersListingServiceModel>> AllAsync()
            => await this.db
                    .Users
                    .ProjectTo<AdminUsersListingServiceModel>()
                    .ToListAsync();
    }
}