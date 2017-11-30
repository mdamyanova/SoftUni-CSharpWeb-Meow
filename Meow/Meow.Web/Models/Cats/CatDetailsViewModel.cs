namespace Meow.Web.Models.Cats
{
    public class CatDetailsViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string ImageUrl { get; set; }

        public string Description { get; set; }

        public string Location { get; set; }

        // depending on this, we'll set cool things on the view
        public bool IsAdopted { get; set; }
    }
}