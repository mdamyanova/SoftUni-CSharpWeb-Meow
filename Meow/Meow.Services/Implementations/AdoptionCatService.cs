namespace Meow.Services.Implementations
{
    using AutoMapper.QueryableExtensions;
    using Contracts;
    using Data;
    using Models;
    using System.Collections.Generic;
    using System.Linq;

    public class AdoptionCatService : IAdoptionCatService
    {
        private MeowDbContext db;

        public AdoptionCatService(MeowDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<CatListingServiceModel> All() 
            => this.db
                .AdoptionCats
                .ProjectTo<CatListingServiceModel>()
                .ToList();

        public AdoptionCatServiceModel ById(int id)
              => this.db
                .AdoptionCats
                .Where(a => a.Id == id)
                .ProjectTo<AdoptionCatServiceModel>()
                .FirstOrDefault();
    }
}