namespace Meow.Web.Models.Account
{
    using Data;
    using Data.Models.Enums;
    using Data.Validation;
    using Microsoft.AspNetCore.Http;
    using System;
    using System.ComponentModel.DataAnnotations;

    public class RegisterViewModel
    {
        [Required]
        [MaxLength(DataConstants.UsernameMaxLength)]
        public string Username { get; set; }

        [Required]
        [MinLength(DataConstants.UserNameMinLength)]
        [MaxLength(DataConstants.UserNameMaxLength)]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "E-mail")]
        public string Email { get; set; }

        public Gender Gender { get; set; }

        [DataType(DataType.Date)]
        [Birthdate(ErrorMessage = "You must be 18 or older to register.")]
        [Display(Name = "Birth date")]
        public DateTime Birthdate { get; set; }

        public string Location { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [Required]
        [DataType(DataType.Upload)]
        [Display(Name = "Profile Photo")]
        public IFormFile ProfilePhoto { get; set; }
    }
}