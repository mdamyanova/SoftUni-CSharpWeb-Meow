namespace Meow.Web.Areas.Cats.Controllers
{
    using Services.Cats.Contracts;
    using Microsoft.AspNetCore.Mvc;

    public class HomeCatsController
    {
        private readonly ICatService cats;

        public HomeCatsController(ICatService cats)
        {
            this.cats = cats;
        }

        public IActionResult Manage()
        {
            var model = this.cats.AllHomeCats();

            return this.View(model);
        }
    }
}
