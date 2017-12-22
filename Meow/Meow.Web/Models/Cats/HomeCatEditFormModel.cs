namespace Meow.Web.Models.Cats
{
    using Data;
    using Data.Models.Enums;
    using System.ComponentModel.DataAnnotations;

    public class HomeCatEditFormModel
    {
        [Required]
        [MinLength(DataConstants.CatNameMinLength)]
        [MaxLength(DataConstants.CatNameMaxLength)]
        public string Name { get; set; }

        [Range(DataConstants.CatMinAge, DataConstants.CatMaxAge)]
        public int Age { get; set; }

        //[DataType(DataType.Upload)]
        //public byte[] Image { get; set; }

        [MaxLength(DataConstants.CatDescriptionMaxLength)]
        public string Description { get; set; }

        public Gender Gender { get; set; }
    }
}