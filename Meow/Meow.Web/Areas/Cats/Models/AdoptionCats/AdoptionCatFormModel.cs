namespace Meow.Web.Areas.Cats.Models.AdoptionCats
{
    using Data;
    using Data.Models.Enums;
    using Data.Validation;
    using Microsoft.AspNetCore.Http;
    using System.ComponentModel.DataAnnotations;

    public class AdoptionCatFormModel
    {
        public int Id { get; set; }

        [Required]
        [MinLength(DataConstants.CatNameMinLength)]
        [MaxLength(DataConstants.CatNameMaxLength)]
        public string Name { get; set; }

        [Range(DataConstants.CatMinAge, DataConstants.CatMaxAge)]
        public int Age { get; set; }
     
        [DataType(DataType.Upload)]
        public IFormFile Image { get; set; }

        [Location]
        public string Location { get; set; }

        [MaxLength(DataConstants.CatDescriptionMaxLength)]
        public string Description { get; set; }

        public Gender Gender { get; set; }
    }
}