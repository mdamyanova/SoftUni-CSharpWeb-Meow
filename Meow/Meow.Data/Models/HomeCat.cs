namespace Meow.Data.Models
{
    using Enums;
    using System.ComponentModel.DataAnnotations;
    using Validation;

    public class HomeCat
    {
        public int Id { get; set; }

        [Required]
        [MinLength(DataConstants.CatNameMinLength)]
        [MaxLength(DataConstants.CatNameMaxLength)]
        public string Name { get; set; }
      
        [Range(DataConstants.CatMinAge, DataConstants.CatMaxAge)]
        public int Age { get; set; }
     
        [Required]
        public byte[] Image { get; set; }

        [MaxLength(DataConstants.CatDescriptionMaxLength)]
        public string Description { get; set; }

        [Required]
        [Location]
        public string Location { get; set; }

        public Gender Gender { get; set; }
       
        public string OwnerId { get; set; }

        public User Owner { get; set; }
    }
}