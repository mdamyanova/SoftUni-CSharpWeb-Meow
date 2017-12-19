namespace Meow.Web.Models
{
    using Data;
    using Data.Models.Enums;
    using Microsoft.AspNetCore.Http;
    using System.ComponentModel.DataAnnotations;

    public class HomeCatFormModel
    {
        [Required]
        [MinLength(DataConstants.CatNameMinLength)]
        [MaxLength(DataConstants.CatNameMaxLength)]
        public string Name { get; set; }

        [Range(DataConstants.CatMinAge, DataConstants.CatMaxAge)]
        public int Age { get; set; }

        [DataType(DataType.Upload)]
        public IFormFile Image { get; set; }

        [MaxLength(DataConstants.CatDescriptionMaxLength)]
        public string Description { get; set; }

        public Gender Gender { get; set; }
    }
}