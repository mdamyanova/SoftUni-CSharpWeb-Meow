namespace Meow.Services.Contracts
{
    using Meow.Services.Models;
    using System.Collections.Generic;

    public interface ICatService
    {
        IEnumerable<CatListingServiceModel> All();

        void Create(string name, string imageUrl, string description, string location, string ownerId);

        void Edit();

        void Delete();
    }
}