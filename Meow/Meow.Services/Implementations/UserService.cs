namespace Meow.Services.Implementations
{
    using AutoMapper.QueryableExtensions;
    using Contracts;
    using Data;
    using Models;
    using System.Linq;

    public class UserService : IUserService
    {
        private readonly MeowDbContext db;

        public UserService(MeowDbContext db)
        {
            this.db = db;
        }

        public UserProfileServiceModel Profile(string id)
            =>  this.db
                .Users
                .Where(u => u.Id == id)
                .ProjectTo<UserProfileServiceModel>()
                .FirstOrDefault();
    }
}