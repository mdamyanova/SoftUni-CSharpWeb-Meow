namespace Meow.Data.Models
{
    using Microsoft.AspNetCore.Identity;
    using System.Collections.Generic;

    public class User : IdentityUser
    {
        public string Name { get; set; }

        public IEnumerable<AdoptionCat> AdoptedCats { get; set; } = new List<AdoptionCat>();

        public IEnumerable<HomeCat> HomeCats { get; set; } = new List<HomeCat>();
    }
}