namespace Meow.Services.Implementations
{
    using AutoMapper.QueryableExtensions;
    using Contracts;
    using Data;
    using Data.Models;
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

        public IEnumerable<CatListingServiceModel> All()
            => this.db
                .HomeCats
                .ProjectTo<CatListingServiceModel>()
                .ToList();

        public bool Add(string name, string imageUrl, string description, string ownerId)
        {
            if (!this.db.Users.Any(u => u.Id == ownerId))
            {
                return false;
            }
            
            var location = this.db.Users.Where(u => u.Id == ownerId).Select(u => u.Location).ToString();

            if (location == null)
            {
                return false;
            }

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

            return true;
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