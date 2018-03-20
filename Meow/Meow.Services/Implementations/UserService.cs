namespace Meow.Services.Implementations
{
    using AutoMapper.QueryableExtensions;
    using Cats.Models;
    using Contracts;
    using Data;
    using Meow.Data.Models.Enums;
    using Microsoft.AspNetCore.Http;
    using Microsoft.EntityFrameworkCore;
    using Models;
    using System;
    using System.Collections.Generic;
    using System.IO;
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

        public async Task<UserProfileServiceModel> ProfileAsync(string id)
             => await this.db
                    .Users
                    .Where(u => u.Id == id)
                    .ProjectTo<UserProfileServiceModel>()
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

        public void Edit(string username, string name, string location, DateTime birthdate, Gender gender, IFormFile image)
        {
            var user = this.db.Users.Find(name);

            if (user == null)
            {
                return;
            }
       
            user.Name = name;
            user.UserName = username;
            user.Location = location;
            user.Birthdate = birthdate;
            user.Gender = gender;

            if (image != null)
            {
                var profilePhoto = new byte[] { };

                // smarter look pls 
                using (var memoryStream = new MemoryStream())
                {
                    image.CopyToAsync(memoryStream);
                    profilePhoto = memoryStream.ToArray();
                }

                user.ProfilePhoto = profilePhoto;
            }
         
            this.db.SaveChanges();
        }

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