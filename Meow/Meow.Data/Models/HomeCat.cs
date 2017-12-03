namespace Meow.Data.Models
{
    using Enums;

    public class HomeCat
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string ImageUrl { get; set; }

        public string Description { get; set; }

        public string Location { get; set; }

        public Gender Gender { get; set; }
       
        public string OwnerId { get; set; }

        public User Owner { get; set; }
    }
}