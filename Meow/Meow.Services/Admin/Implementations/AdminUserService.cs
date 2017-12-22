namespace Meow.Services.Admin.Implementations
{
    using AutoMapper.QueryableExtensions;
    using Data;
    using Services.Admin.Models;
    using Services.Contracts;
    using System.Collections.Generic;
    using System.Linq;

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