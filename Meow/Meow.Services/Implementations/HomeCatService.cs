namespace Meow.Services.Implementations
{
    using AutoMapper.QueryableExtensions;
    using Contracts;
    using Data;
    using Data.Models;
    using Data.Models.Enums;
    using Models;
    using System.Collections.Generic;
    using System.Linq;

    public class HomeCatService : IHomeCatService
    {
        private MeowDbContext db;

        public HomeCatService(MeowDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<HomeCatListingServiceModel> All()
            => this.db
                .HomeCats
                .ProjectTo<HomeCatListingServiceModel>()
                .ToList();

        public HomeCatServiceModel ById(int id)
              => this.db
                .HomeCats
                .Where(a => a.Id == id)
                .ProjectTo<HomeCatServiceModel>()
                .FirstOrDefault();

        public bool Exists(int id)
        {
            return this.db.HomeCats.Any(c => c.Id == id);
        }

        public bool Add(string name, int age, string imageUrl, string description, Gender gender, string ownerId)
        {
            if (!this.db.Users.Any(u => u.Id == ownerId))
            {
                return false;
            }
            
            var location = this.db
                .Users
                .Where(u => u.Id == ownerId)
                .Select(u => u.Location)
                .FirstOrDefault();

            if (location == null)
            {
                return false;
            }

            var homeCat = new HomeCat
            {
                Name = name,
                Age = age,
                ImageUrl = imageUrl,
                Description = description,
                Gender = gender,
                OwnerId = ownerId,
                Location = location
            };

            this.db.Add(homeCat);

            this.db.SaveChanges();

            return true;
        } 

        public void Edit(int id, string name, int age, string imageUrl, string description, Gender gender)
        {
            var homeCat = this.db.HomeCats.Find(id);

            if (homeCat == null)
            {
                return;
            }

            // smarter look pls 

            homeCat.Name = name;
            homeCat.Age = age;
            homeCat.ImageUrl = imageUrl;
            homeCat.Description = description;
            homeCat.Gender = gender;

            this.db.SaveChanges();
        }

        public bool Remove(int id)
        {
            var homeCat = this.db.HomeCats.Find(id);

            if (homeCat == null)
            {
                return false;
            }

            this.db.HomeCats.Remove(homeCat);
            this.db.SaveChanges();

            return true;
        }
    }
}