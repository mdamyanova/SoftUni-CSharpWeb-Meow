namespace Meow.Services.Implementations
{
    using AutoMapper.QueryableExtensions;
    using Cats.Models;
    using Contracts;
    using Data;
    using Microsoft.EntityFrameworkCore;
    using Models;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

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

        public async Task<UserProfileServiceModel> ProfileAsync(string id, string role)
             => await this.db
                    .Users
                    .Where(u => u.Id == id)
                    .ProjectTo<UserProfileServiceModel>(new { userId = id, UserRole = role })
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

        public bool Remove(string id)
        {
            // first remove cats
            var homeCats = this.db.HomeCats.Where(c => c.OwnerId == id);

            if (homeCats.Any())
            {
                this.db.RemoveRange(homeCats);
            }

            var adoptedCats = this.db.AdoptionCats.Where(c => c.OwnerId == id);

            if (adoptedCats.Any())
            {
                this.db.RemoveRange(adoptedCats);
            }

            var user = this.db.Users.Find(id);

            if (user == null)
            {
                return false;
            }

            this.db.Users.Remove(user);
            this.db.SaveChanges();

            return true;
        }
    }
}