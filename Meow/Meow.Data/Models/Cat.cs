namespace Meow.Data.Models
{
    public class Cat
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string ImageUrl { get; set; }

        public string Description { get; set; }


        // relation with user?

        // maybe the owner is the admin by default and if he's agreed for adoption,
        //we will change it to the user requested it? :) 
    }
}