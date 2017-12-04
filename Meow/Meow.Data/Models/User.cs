namespace Meow.Data.Models
{
    using Microsoft.AspNetCore.Identity;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Validation;

    public class User : IdentityUser
    {
        [Required]
        [MinLength(DataConstants.UserNameMinLength)]
        [MaxLength(DataConstants.UserNameMaxLength)]
        public string Name { get; set; }

        // I don't want to make it byte array ;(
        //public string ProfilePhotoUrl { get; set; }

        [Required]
        [Location]
        public string Location { get; set; }
        
        [Birthdate]
        public DateTime Birthdate { get; set; }

        public IEnumerable<AdoptionCat> AdoptedCats { get; set; } = new List<AdoptionCat>();

        public IEnumerable<HomeCat> HomeCats { get; set; } = new List<HomeCat>();
    }
}