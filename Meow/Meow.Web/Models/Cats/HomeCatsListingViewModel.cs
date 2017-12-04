namespace Meow.Web.Models.Cats
{
    using System.Collections.Generic;

    public class HomeCatsListingViewModel
    {
        public IEnumerable<HomeCatDetailsViewModel> Cats { get; set; } = new List<HomeCatDetailsViewModel>();
    }
}