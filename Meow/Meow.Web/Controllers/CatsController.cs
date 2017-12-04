namespace Meow.Web.Controllers
{
    using Services.Contracts;
    using Microsoft.AspNetCore.Mvc;
    using Meow.Web.Models.HomeCats;
    using Microsoft.AspNetCore.Identity;
    using Meow.Data.Models;
    using Microsoft.AspNetCore.Authorization;

    public class CatsController : Controller
    {
        private readonly UserManager<User> userManager;
        private readonly ICatService homeCats;

        // todo: fix it
        public CatsController(UserManager<User> userManager, IHomeCatService homeCats)
        {
            this.userManager = userManager;
            this.homeCats = homeCats;
        }

        // all home cats
        public IActionResult All()
        {
            var model = this.homeCats.All();
            return this.View(model);
        }

        // all adoption cats 
        public IActionResult Adoption()
        {
            var model = this.adoptionCats.All();
            return this.View();
        }

        public IActionResult Details(int id)
        {
            // todo 
            return null;
        }

        [Authorize]
        public IActionResult Add()
        {
            return this.View();
        }

        [HttpPost]
        [Authorize]
        public IActionResult Add(AddHomeCatFormModel model)
        {
            var ownerId = this.userManager.GetUserId(User);

            this.homeCats.Create(model.Name, model.ImageUrl, model.Description, ownerId);

            //this.TempData.AddSuccessMessage($"The cat {model.Name} was added successfully!");

            return this.RedirectToAction(nameof(HomeController.Index), "Home");
        }
    }
}