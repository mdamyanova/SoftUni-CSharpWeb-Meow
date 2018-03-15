using Meow.Services.Cats.Models;

namespace Meow.Services.Cats.Contracts
{
    using System.Collections.Generic;
    using Data.Models.Enums;
    using Volunteer.Models;
    using Microsoft.AspNetCore.Http;

    public interface ICatService
    {
        IEnumerable<AdoptionCatListingServiceModel> AllAdoptionCats();
        IEnumerable<HomeCatListingServiceModel> AllHomeCats();

        AdoptionCatServiceModel ById(int id);

        bool Exists(int id);

        bool Add(string name, IFormFile image, int age, string location, string description, Gender gender);

        void Edit(int id, string name, int age, IFormFile image, string description, Gender gender, string ownerId);

        bool Remove(int id);

        IEnumerable<AdoptionCatListingServiceModel> Requested();

        bool Adopt(int id, string username);

        bool Give(int id);
    }
}
