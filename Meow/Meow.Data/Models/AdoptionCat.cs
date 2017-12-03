using Meow.Data.Models.Enums;

namespace Meow.Data.Models
{
    public class AdoptionCat
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string ImageUrl { get; set; }

        public string Description { get; set; }

        // todo: custom validation attribute
        public string Location { get; set; }

        // this will be false in creation? 
        public bool IsAdopted { get; set; }

        public Gender Gender { get; set; }

        // maybe the owner is the admin by default and if he's agreed for adoption,
        //we will change it to the user requested it? :) 
        public string OwnerId { get; set; }

        public User Owner { get; set; }
    }
}