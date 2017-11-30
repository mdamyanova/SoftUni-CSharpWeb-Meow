namespace Meow.Services.Implementations
{
    using Admin.Models;
    using Contracts;
    using Web.Data;
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper.QueryableExtensions;

    public class CatService : ICatService
    {
        private readonly MeowDbContext db;

        public CatService(MeowDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<CatServiceModel> All()
        {
            var allCats = this.db.Cats.ProjectTo<CatServiceModel>().ToList();

            return allCats;
        }
    }
}