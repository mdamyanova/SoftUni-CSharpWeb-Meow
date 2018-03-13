namespace Meow.Services.Volunteer.Implementations
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

        // by default the owner is set to be the volunteer profile
        public bool Add(string name, IFormFile image, int age, string location, string description, Gender gender)
        {
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

        public IEnumerable<AdoptionCatListingServiceModel> All()
            => this.db
                .AdoptionCats
                .ProjectTo<AdoptionCatListingServiceModel>()
                .ToList();

        public AdoptionCatServiceModel ById(int id)
              => this.db
                .AdoptionCats
                .Where(a => a.Id == id)
                .ProjectTo<AdoptionCatServiceModel>()
                .FirstOrDefault();

        public void Edit(int id, string name, int age, IFormFile image, string description, Gender gender, string ownerId)
        {
            var cat = this.db.AdoptionCats.Find(id);

            if (cat == null)
            {
                return;
            }
            var img = new byte[] { };

            // smarter look pls -- I think its okay/Kalin
            using (var memoryStream = new MemoryStream())
            {
                image.CopyToAsync(memoryStream);
                img = memoryStream.ToArray();
            }

            cat.Name = name;
            cat.Age = age;
            cat.Image = img;
            cat.Description = description;
            cat.Gender = gender;

            this.db.SaveChanges();
        }

        public bool Exists(int id)
        {
            return this.db.AdoptionCats.Any(c => c.Id == id);
        }

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

            this.db.SaveChanges();

            return true;
        }
    }
}