namespace Meow.Services.Implementations
{
    using AutoMapper.QueryableExtensions;
    using Contracts;
    using Data;
    using Models;
    using System.Linq;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;

    public class UserService : IUserService
    {
        private readonly MeowDbContext db;

        public UserService(MeowDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<UserListingServiceModel> All()
            => this.db
                .Users
                .ProjectTo<UserListingServiceModel>()
                .ToList();

        public UserProfileServiceModel Profile(string id)
            => this.db
                .Users
                .Where(u => u.Id == id)
                .ProjectTo<UserProfileServiceModel>()
                .FirstOrDefault();

        public async Task<UserProfileServiceModel> ProfileAsync(string id)
         => await this.db
                .Users
                .Where(u => u.Id == id)
                .ProjectTo<UserProfileServiceModel>(new { userId = id })
                .FirstOrDefaultAsync();
    }
}