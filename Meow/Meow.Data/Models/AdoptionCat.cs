﻿namespace Meow.Data.Models
{
    using Enums;
    using Validation;
    using System.ComponentModel.DataAnnotations;

    public class AdoptionCat
    {
        public int Id { get; set; }

        [Required]
        [MinLength(DataConstants.CatNameMinLength)]
        [MaxLength(DataConstants.CatNameMaxLength)]
        public string Name { get; set; }

        [Range(DataConstants.CatMinAge, DataConstants.CatMaxAge)]
        public int Age { get; set; }

        [Required]
        [MinLength(DataConstants.ImageUrlMinLength)]
        [MaxLength(DataConstants.ImageUrlMaxLength)]
        public string ImageUrl { get; set; }

        [MaxLength(DataConstants.CatDescriptionMaxLength)]
        public string Description { get; set; }

        [Required]
        [Location]
        public string Location { get; set; }

        public Gender Gender { get; set; }

        public bool IsAdopted { get; set; }

        public string OwnerId { get; set; }

        public User Owner { get; set; }
    }
}