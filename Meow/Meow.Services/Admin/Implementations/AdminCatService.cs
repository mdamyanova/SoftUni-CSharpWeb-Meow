namespace Meow.Services.Admin.Implementations
{
    using AutoMapper.QueryableExtensions;
    using Contracts;
    using Data;
    using Services.Models;
    using System.Collections.Generic;
    using System.Linq;

    public class AdminCatService : IAdminCatService
    {
        private readonly MeowDbContext db;

        public AdminCatService(MeowDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<HomeCatListingServiceModel> All()
         => this.db
                .HomeCats
                .ProjectTo<HomeCatListingServiceModel>()
                .ToList();
    }
}