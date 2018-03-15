namespace Meow.Web.Areas.Cats.Models.HomeCats
{
    using Data.Models.Enums;

    public class HomeCatDetailsViewModel
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public string ImageUrl { get; set; }

        public string Description { get; set; }

        public string Location { get; set; }

        public Gender Gender { get; set; }

        public string OwnerId { get; set; }

        public string Owner { get; set; }
    }
}