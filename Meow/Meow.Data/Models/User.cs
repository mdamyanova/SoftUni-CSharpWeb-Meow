namespace Meow.Data.Models
{
    using Microsoft.AspNetCore.Identity;
    using System.Collections.Generic;

    public class User : IdentityUser
    {
        public string Name { get; set; }

        public IEnumerable<Cat> Cats { get; set; } = new List<Cat>();
    }
}