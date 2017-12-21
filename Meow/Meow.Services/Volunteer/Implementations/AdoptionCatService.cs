namespace Meow.Services.Volunteer.Implementations
{
    using AutoMapper.QueryableExtensions;
    using Contracts;
    using Data;
    using Models;
    using System.Collections.Generic;
    using System.Linq;
    using Meow.Data.Models.Enums;
    using Microsoft.AspNetCore.Http;
    using Meow.Core;
    using Meow.Data.Models;
    using System.IO;

    public class AdoptionCatService : IAdoptionCatService
    {
        private MeowDbContext db;

        public AdoptionCatService(MeowDbContext db)
        {
            this.db = db;
        }

        public bool Add(string name, IFormFile image, int age, string location, string description, Gender gender)
        {
            if (!this.db.Users.Any(u => u.UserName == WebConstants.AdministratorUsername))
            {
                return false;
            }

            var adminId = this.db
                    .Users
                    .Where(u => u.UserName == WebConstants.AdministratorUsername)
                    .Select(u => u.Id)
                    .FirstOrDefault();

            var cat = new AdoptionCat
            {
                Name = name,
                Age = age,
                Description = description,
                Gender = gender,
                OwnerId = adminId,
                Location = location
            };

            using (var memoryStream = new MemoryStream())
            {
                image.CopyToAsync(memoryStream);
                cat.Image = memoryStream.ToArray();
            }

            this.db.Add(cat);

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
            var homeCat = this.db.HomeCats.Find(id);

            if (homeCat == null)
            {
                return;
            }
            var img = new byte[] { };

            // smarter look pls 
            using (var memoryStream = new MemoryStream())
            {
                image.CopyToAsync(memoryStream);
                img = memoryStream.ToArray();
            }

            homeCat.Name = name;
            homeCat.Age = age;
            homeCat.Image = img;
            homeCat.Description = description;
            homeCat.Gender = gender;

            this.db.SaveChanges();
        }

        public bool Exists(int id)
        {
            return this.db.AdoptionCats.Any(c => c.Id == id);
        }

        public bool Give(int id, string requestedOwnerId)
        {
            if (!this.db.AdoptionCats.Any(c => c.Id == id))
            {
                return false;
            }

            if (!this.db.Users.Any(u => u.Id == requestedOwnerId))
            {
                return false;
            }


            var cat = this.db.AdoptionCats.FirstOrDefault(c => c.Id == id);
            var owner = this.db.Users.FirstOrDefault(u => u.Id == requestedOwnerId);

            cat.IsRequested = false;
            cat.IsAdopted = true;
            cat.Owner = owner;

            this.db.SaveChanges();

            return true;
        }

        public bool Remove(int id)
        {
            var adoptionCat = this.db.AdoptionCats.Find(id);

            if (adoptionCat == null)
            {
                return false;
            }

            this.db.AdoptionCats.Remove(adoptionCat);
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

            if (cat == null || user == null)
            {
                return false;
            }

            cat.IsRequested = true;
            cat.RequestedOwnerId = user.Id;

            this.db.SaveChanges();

            return true;
        }

        public bool Give(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}