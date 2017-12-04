namespace Meow.Services.Implementations
{
    using Contracts;
    using Data.Models;
    using Models;
    using System.Collections.Generic;
    using System.Linq;
    using Web.Data;

    public class HomeCatService : ICatService
    {
        private MeowDbContext db;

        public HomeCatService(MeowDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<CatListingServiceModel> All()
        {
            throw new System.NotImplementedException();
        }

        // todo: make it bool and return false where there's invalid data?
        public void Create(string name, string imageUrl, string description, string location, string ownerId)
        {
            // some nasty logic for the location, you know

            //var location = this.db.Users.Where(u => u.Id == ownerId).Select(u => u.Location).ToString();

            //if (location == null)
            //{
            //    return;
            //}

            var homeCat = new HomeCat
            {
                Name = name,
                ImageUrl = imageUrl,
                Description = description,
                OwnerId = ownerId,
                Location = location
            };

            this.db.Add(homeCat);

            this.db.SaveChanges();
        } 

        public void Delete()
        {
            throw new System.NotImplementedException();
        }

        public void Edit()
        {
            throw new System.NotImplementedException();
        }
    }
}