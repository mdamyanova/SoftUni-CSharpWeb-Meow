namespace Meow.Services.Contracts
{
    using Models;
    using System.Collections.Generic;

    public interface IHomeCatService
    {
        IEnumerable<CatListingServiceModel> All();

        bool Add(string name, string imageUrl, string description, string ownerId);
    }
}