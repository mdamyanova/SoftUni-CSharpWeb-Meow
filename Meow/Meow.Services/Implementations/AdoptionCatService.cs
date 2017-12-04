namespace Meow.Services.Implementations
{
    using System.Collections.Generic;
    using Contracts;
    using Models;
    using Meow.Data;
    using Meow.Data.Models;

    public class AdoptionCatService : ICatService
    {
        private MeowDbContext db;

        public AdoptionCatService(MeowDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<CatListingServiceModel> All()
        {
            throw new System.NotImplementedException();
        }

        public void Create(string name, string imageUrl, string description, string location, string ownerId)
        {
            var adoptionCat = new AdoptionCat
            {
                Name = name,
                ImageUrl = imageUrl,
                Description = description,
                OwnerId = ownerId,
                Location = location
            };

            this.db.Add(adoptionCat);

            this.db.SaveChanges();
        }

        public void Edit()
        {
            throw new System.NotImplementedException();
        }

        public void Delete()
        {
            throw new System.NotImplementedException();
        }
    }
}