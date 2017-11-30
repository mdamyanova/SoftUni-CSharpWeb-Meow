namespace Meow.Services.Admin.Implementations
{
    using Contracts;
    using Data.Models;
    using Web.Data;

    public class CatService : ICatService
    {
        private readonly MeowDbContext db;

        public CatService(MeowDbContext db)
        {
            this.db = db;
        }

        public void Add(string name, string imageUrl, string description, string location, string ownerId)
        {
            var cat = new Cat
            {
                Name = name,
                ImageUrl = imageUrl,
                Description = description,
                Location = location,
                OwnerId = ownerId,
                IsAdopted = false,
            };

            this.db.Add(cat);
            this.db.SaveChanges();
        }      
    }
}