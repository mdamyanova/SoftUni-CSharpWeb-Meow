namespace Meow.Services.Models
{
    using Core.Mapping;
    using Data.Models;
    using Data.Models.Enums;
    using System;
    using System.Collections.Generic;
    using Volunteer.Models;

    public class UserProfileServiceModel : IMapFrom<User>
    {
        public string Id { get; set; }

        public string UserName { get; set; }

        public string Name { get; set; }

        public DateTime Birthdate { get; set; }

        public Gender Gender { get; set; }

        public byte[] ProfilePhoto { get; set; }

        public string Email { get; set; }

        public string UserRole { get; set; }

        public IEnumerable<HomeCatServiceModel> HomeCats { get; set; }

        public IEnumerable<AdoptionCatListingServiceModel> AdoptedCats { get; set; }
    }
}