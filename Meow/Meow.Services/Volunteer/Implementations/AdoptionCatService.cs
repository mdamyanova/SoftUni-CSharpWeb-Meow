namespace Meow.Services.Volunteer.Implementations
{
    using AutoMapper.QueryableExtensions;
    using Contracts;
    using Data;
    using Models;
    using System.Collections.Generic;
    using System.Linq;
    using Meow.Data.Models.Enums;

    public class AdoptionCatService : IAdoptionCatService
    {
        private MeowDbContext db;

        public AdoptionCatService(MeowDbContext db)
        {
            this.db = db;
        }

        public bool Add(string name, int age, string imageUrl, string description, Gender gender, string ownerId)
        {
            throw new System.NotImplementedException();
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

        public void Edit(int id, string name, int age, string imageUrl, string description, Gender gender)
        {
            var adoptionCat = this.db.AdoptionCats.Find(id);

            if (adoptionCat == null)
            {
                return;
            }

            // smarter look pls 

            adoptionCat.Name = name;
            adoptionCat.Age = age;
            adoptionCat.ImageUrl = imageUrl;
            adoptionCat.Description = description;
            adoptionCat.Gender = gender;

            this.db.SaveChanges();
        }

        public bool Exists(int id)
        {
            return this.db.AdoptionCats.Any(c => c.Id == id);
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
    }
}