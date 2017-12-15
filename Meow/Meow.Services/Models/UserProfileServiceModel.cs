namespace Meow.Services.Models
{
    using Core.Mapping;
    using Data.Models;
    using System;
    using System.Collections.Generic;

    public class UserProfileServiceModel : IMapFrom<User>
    {
        public string UserName { get; set; }

        public string Name { get; set; }

        public DateTime Birthdate { get; set; }

        public IEnumerable<HomeCatServiceModel> HomeCats { get; set; }
    }
}