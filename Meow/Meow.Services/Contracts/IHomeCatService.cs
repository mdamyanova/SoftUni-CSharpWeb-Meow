namespace Meow.Services.Contracts
{
    using Data.Models.Enums;
    using Models;
    using System.Collections.Generic;

    public interface IHomeCatService
    {
        IEnumerable<CatListingServiceModel> All();

        HomeCatServiceModel ById(int id);

        bool Add(string name, int age, string imageUrl, string description, Gender gender, string ownerId);
    }
}