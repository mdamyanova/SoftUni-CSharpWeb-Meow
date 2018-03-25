namespace Meow.Services.Cats.Implementations
{
    using AutoMapper.QueryableExtensions;
    using Contracts;
    using Core;
    using Data;
    using Data.Models;
    using Data.Models.Enums;
    using Microsoft.AspNetCore.Http;
    using Models;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class AdoptionCatService : IAdoptionCatService
    {
        private MeowDbContext db;

        public AdoptionCatService(MeowDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<AdoptionCatListingServiceModel> All()
            => this.db
                .AdoptionCats
                .ProjectTo<AdoptionCatListingServiceModel>()
                .ToList();

        // by default the owner is set to be the volunteer profile
        public bool Add(string name, IFormFile image, int age, string location, string description, Gender gender)
        {
            if (this.db.AdoptionCats.Any(c => c.Name == name))
            {
                return false;
            }

            if (!this.db.Users.Any(u => u.UserName == WebConstants.VolunteerUsername))
            {
                return false;
            }

            var volunteerId = this.db
                    .Users
                    .Where(u => u.UserName == WebConstants.VolunteerUsername)
                    .Select(u => u.Id)
                    .FirstOrDefault();

            var cat = new AdoptionCat
            {
                Name = name,
                Age = age,
                Description = description,
                Gender = gender,
                OwnerId = volunteerId,
                Owner = this.db.Users.FirstOrDefault(u => u.Id == volunteerId),
                Location = location
            };

            using (var memoryStream = new MemoryStream())
            {
                image.CopyToAsync(memoryStream);
                cat.Image = memoryStream.ToArray();
            }

            this.db.AdoptionCats.Add(cat);
            this.db.SaveChanges();

            return true;
        }

        public AdoptionCatServiceModel ById(int id)
        {
            var cat = this.db
                .AdoptionCats
                .Where(a => a.Id == id)
                .ProjectTo<AdoptionCatServiceModel>()
                .FirstOrDefault();

            foreach (var adoptionCatUser in cat.Adopters)
            {
                var adobter = this.db.Users.FirstOrDefault(u => u.Id == adoptionCatUser.AdopterId);

                cat.AdoptersList.Add(adobter);
            }

            return cat;
        }


        public void Edit(int id, string name, int age, IFormFile image, string description, Gender gender, string ownerId)
        {
            var cat = this.db.AdoptionCats.Find(id);

            if (cat == null)
            {
                return;
            }

            if (image != null)
            {
                var catImage = new byte[] { };

                // smarter look pls 
                using (var memoryStream = new MemoryStream())
                {
                    image.CopyToAsync(memoryStream);
                    catImage = memoryStream.ToArray();
                }

                cat.Image = catImage;
            }

            cat.Name = name;
            cat.Age = age;
            cat.Description = description;
            cat.Gender = gender;

            this.db.SaveChanges();
        }

        public bool Exists(int id)
            => this.db.AdoptionCats.Any(c => c.Id == id);     

        public bool Give(int id)
        {
            if (!this.db.AdoptionCats.Any(c => c.Id == id))
            {
                return false;
            }

            var cat = this.db.AdoptionCats.FirstOrDefault(c => c.Id == id);
            var owner = this.db.Users.FirstOrDefault(u => u.Id == cat.RequestedOwnerId);

            cat.IsRequested = false;
            cat.IsAdopted = true;
            cat.Owner = owner;

            this.db.SaveChanges();

            return true;
        }

        public bool Remove(int id)
        {
            var cat = this.db.AdoptionCats.Find(id);

            if (cat == null)
            {
                return false;
            }

            this.db.AdoptionCats.Remove(cat);
            this.db.SaveChanges();

            return true;
        }

        public IEnumerable<AdoptionCatListingServiceModel> Requested()
            => this.db
                .AdoptionCats
                .Where(a => a.IsRequested)
                .ProjectTo<AdoptionCatListingServiceModel>()
                .ToList();

        public bool Adopt(int id, string username)
        {
            var cat = this.db.AdoptionCats.FirstOrDefault(c => c.Id == id);
            var user = this.db.Users.FirstOrDefault(u => u.UserName == username);

            if (cat == null || user == null || cat.OwnerId == user.Id)
            {
                return false;
            }

            cat.IsRequested = true;
            cat.RequestedOwnerId = user.Id;

            var adoptionCatUser = new AdoptionCatUser
            {
                AdopterId = user.Id,
                AdoptionCatId = id
            };

            this.db.Add(adoptionCatUser);

            this.db.SaveChanges();

            return true;
        }
    }
}