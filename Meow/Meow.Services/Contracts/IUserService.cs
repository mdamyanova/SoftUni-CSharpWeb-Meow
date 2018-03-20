namespace Meow.Services.Contracts
{
    using Cats.Models;
    using Meow.Data.Models.Enums;
    using Microsoft.AspNetCore.Http;
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IUserService
    {
        bool Exists(string id);
        
        IEnumerable<UserListingServiceModel> All();

        Task<UserProfileServiceModel> ProfileAsync(string usernameS);

        Task<IEnumerable<HomeCatListingServiceModel>> HomeCatsAsync(string id);

        Task<IEnumerable<AdoptionCatListingServiceModel>> AdoptedCatsAsync(string id);

        bool Remove(string id);

        void Edit(string username, string name, string location, DateTime birthdate, Gender gender, IFormFile image);
    }
}