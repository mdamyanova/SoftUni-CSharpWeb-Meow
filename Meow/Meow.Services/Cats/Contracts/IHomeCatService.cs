namespace Meow.Services.Cats.Contracts
{
    using Data.Models.Enums;
    using Microsoft.AspNetCore.Http;
    using Models;
    using System.Collections.Generic;

    public interface IHomeCatService
    {
        IEnumerable<HomeCatListingServiceModel> All();

        HomeCatServiceModel ById(int id);

        bool Exists(int id);

        bool Add(string name, IFormFile image, int age, string description, Gender gender, string ownerId);
 
        // todo - edit image if have time
        void Edit(int id, string name, int age, string description, IFormFile image, Gender gender);

        bool Remove(int id);
    }
}