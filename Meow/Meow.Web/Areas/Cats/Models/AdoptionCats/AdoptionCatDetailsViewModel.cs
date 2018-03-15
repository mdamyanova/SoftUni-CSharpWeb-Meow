namespace Meow.Web.Areas.Cats.Models.AdoptionCats
{
    using Data.Models.Enums;

    public class AdoptionCatDetailsViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public byte[] Image { get; set; }

        public string Description { get; set; }

        public string Location { get; set; }

        public Gender Gender { get; set; }

        public string Owner { get; set; }

        public bool IsAdopted { get; set; }

        public bool IsRequested { get; set; }
    }
}