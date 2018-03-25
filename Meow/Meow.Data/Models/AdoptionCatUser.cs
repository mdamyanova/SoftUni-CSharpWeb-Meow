namespace Meow.Data.Models
{
    public class AdoptionCatUser
    {
        public string AdopterId { get; set; }

        public User Adopter { get; set; }

        public int AdoptionCatId { get; set; }

        public AdoptionCat AdoptionCat { get; set; }
    }
}
