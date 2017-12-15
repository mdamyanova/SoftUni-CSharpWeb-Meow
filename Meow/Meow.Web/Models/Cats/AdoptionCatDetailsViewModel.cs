namespace Meow.Web.Models.Cats
{
    using Data.Models.Enums;

    public class AdoptionCatDetailsViewModel
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public string ImageUrl { get; set; }

        public string Description { get; set; }

        public string Location { get; set; }

        public Gender Gender { get; set; }

        public bool IsAdopted { get; set; }
    }
}