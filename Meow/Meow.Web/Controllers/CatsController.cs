namespace Meow.Web.Controllers
{
    using Services.Contracts;
    using Microsoft.AspNetCore.Mvc;

    public class CatsController : Controller
    {
        private readonly ICatService cats;

        public CatsController(ICatService cats)
        {
            this.cats = cats;
        }

        public IActionResult All()
        {
            var model = this.cats.All();
            return this.View(model);
        }

        public IActionResult Details(int id)
        {
            // todo 
            return null;
        }
    }
}