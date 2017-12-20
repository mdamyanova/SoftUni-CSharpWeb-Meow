namespace Meow.Services.Models
{
    using Core.Mapping;
    using Data.Models;
    using Meow.Data.Models.Enums;
    using Meow.Services.Volunteer.Models;
    using System;
    using System.Collections.Generic;

    public class UserProfileServiceModel : IMapFrom<User>
    {
        public string UserName { get; set; }

        public string Name { get; set; }

        public DateTime Birthdate { get; set; }

        public Gender Gender { get; set; }

        public byte[] ProfilePhoto { get; set; }

        public string Email { get; set; }

        public IEnumerable<HomeCatServiceModel> HomeCats { get; set; }

        public IEnumerable<AdoptionCatListingServiceModel> AdoptedCats { get; set; }
    }
}