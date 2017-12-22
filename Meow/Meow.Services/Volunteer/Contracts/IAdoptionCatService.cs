namespace Meow.Services.Volunteer.Contracts
{
    using Data.Models.Enums;
    using Microsoft.AspNetCore.Http;
    using Models;
    using System.Collections.Generic;

    public interface IAdoptionCatService
    {
        IEnumerable<AdoptionCatListingServiceModel> All();

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