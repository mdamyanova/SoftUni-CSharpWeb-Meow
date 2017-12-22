namespace Meow.Services.Implementations
{
    using AutoMapper.QueryableExtensions;
    using Contracts;
    using Data;
    using Microsoft.EntityFrameworkCore;
    using Models;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Volunteer.Models;

    public class UserService : IUserService
    {
        private readonly MeowDbContext db;

        public UserService(MeowDbContext db)
        {
            this.db = db;
        }

        public bool Exists(string id)
        {
            return this.db.Users.Any(c => c.Id == id);
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

        public async Task<IEnumerable<HomeCatListingServiceModel>> HomeCatsAsync(string id)
            => await this.db
                .HomeCats
                .Where(c => c.OwnerId == id)
                .ProjectTo<HomeCatListingServiceModel>()
                .ToListAsync();

        public async Task<IEnumerable<AdoptionCatListingServiceModel>> AdoptedCatsAsync(string id)
            => await this.db
                .AdoptionCats
                .Where(c => c.OwnerId == id)
                .ProjectTo<AdoptionCatListingServiceModel>()
                .ToListAsync();
    }
}