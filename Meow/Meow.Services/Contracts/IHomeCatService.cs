namespace Meow.Services.Contracts
{
    using Data.Models.Enums;
    using Models;
    using System.Collections.Generic;

    public interface IHomeCatService
    {
        IEnumerable<HomeCatListingServiceModel> All();

        HomeCatServiceModel ById(int id);

        bool Exists(int id);

        bool Add(string name, int age, string imageUrl, string description, Gender gender, string ownerId);
 
        void Edit(int id, string name, int age, string imageUrl, string description, Gender gender);

        bool Remove(int id);
    }
}