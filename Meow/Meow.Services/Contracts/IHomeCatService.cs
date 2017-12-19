﻿namespace Meow.Services.Contracts
{
    using Data.Models.Enums;
    using Microsoft.AspNetCore.Http;
    using Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IHomeCatService
    {
        IEnumerable<HomeCatListingServiceModel> All();

        HomeCatServiceModel ById(int id);

        bool Exists(int id);

        bool Add(string name, IFormFile image, int age, string description, Gender gender, string ownerId);
 
        void Edit(int id, string name, int age, IFormFile image, string description, Gender gender);

        bool Remove(int id);
    }
}