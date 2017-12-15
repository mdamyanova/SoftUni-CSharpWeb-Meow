namespace Meow.Web.Areas.Volunteer.Models
{
    using Data;
    using Data.Models.Enums;
    using System.ComponentModel.DataAnnotations;

    public class AdoptionCatFormModel
    {
        [Required]
        [MinLength(DataConstants.CatNameMinLength)]
        [MaxLength(DataConstants.CatNameMaxLength)]
        public string Name { get; set; }

        [Range(DataConstants.CatMinAge, DataConstants.CatMaxAge)]
        public int Age { get; set; }

        [Required]
        [MinLength(DataConstants.ImageUrlMinLength)]
        [MaxLength(DataConstants.ImageUrlMaxLength)]
        [Display(Name = "Image URL")]
        public string ImageUrl { get; set; }

        [MaxLength(DataConstants.CatDescriptionMaxLength)]
        public string Description { get; set; }

        public Gender Gender { get; set; }
    }
}