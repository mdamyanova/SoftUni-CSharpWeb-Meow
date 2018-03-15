namespace Meow.Data.Models
{

    using System.ComponentModel.DataAnnotations;
    using Enums;
    using Validation;

    using static DataConstants;

    public abstract class Cat
    {
        public int Id { get; set; }

        [Required]
        [MinLength(CatNameMinLength)]
        [MaxLength(CatNameMaxLength)]
        public string Name { get; set; }

        [Range(CatMinAge, CatMaxAge)]
        public int Age { get; set; }

        public byte[] Image { get; set; }

        [MaxLength(CatDescriptionMaxLength)]
        public string Description { get; set; }

        [Required]
        [Location]
        public string Location { get; set; }

        public Gender Gender { get; set; }

        public string OwnerId { get; set; }

        public User Owner { get; set; }
    }
}
