namespace Meow.Web.Models
{
    using Data;
    using Data.Models.Enums;
    using Data.Validation;
    using Microsoft.AspNetCore.Http;
    using System;
    using System.ComponentModel.DataAnnotations;

    public class UserFormModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        [MinLength(DataConstants.UserNameMinLength)]
        [MaxLength(DataConstants.UserNameMaxLength)]
        public string Name { get; set; }

        [Required]
        [Location]
        public string Location { get; set; }

        [Birthdate]
        public DateTime Birthdate { get; set; }
    
        public IFormFile Image { get; set; }

        public Gender Gender { get; set; }
    }
}