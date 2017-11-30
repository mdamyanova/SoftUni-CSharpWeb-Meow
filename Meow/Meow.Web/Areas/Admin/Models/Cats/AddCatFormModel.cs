namespace Meow.Web.Areas.Admin.Models.Cats
{
    public class AddCatFormModel
    {
        //todo: add validation attributes

        public string Name { get; set; }

        public string ImageUrl { get; set; }

        public string Description { get; set; }

        public string Location { get; set; }
    }
}