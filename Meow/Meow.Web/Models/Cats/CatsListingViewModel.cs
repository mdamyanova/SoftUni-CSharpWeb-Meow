namespace Meow.Web.Models.Cats
{
    using System.Collections.Generic;

    public class CatsListingViewModel
    {
        public IEnumerable<CatDetailsViewModel> Cats { get; set; } = new List<CatDetailsViewModel>();
    }
}