namespace Meow.Services.Admin.Implementations
{
    using AutoMapper.QueryableExtensions;
    using Contracts;
    using Data;
    using Meow.Services.Contracts;
    using Microsoft.EntityFrameworkCore;
    using Services.Admin.Models;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class AdminUserService : IAdminUserService
    {
        private readonly MeowDbContext db;

        public AdminUserService(MeowDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<AdminUsersListingServiceModel> All()
            => this.db
                .Users
                .ProjectTo<AdminUsersListingServiceModel>()
                .ToList();
    }
}