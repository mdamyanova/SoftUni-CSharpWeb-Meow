namespace Meow.Web.Controllers
{
    using Data.Models;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Models.HomeCats;
    using Services.Contracts;

    public class CatsController : Controller
    {
        private readonly UserManager<User> userManager;
        private readonly IHomeCatService homeCats;

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
            //var model = this.adoptionCats.All();
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

            var success = this.homeCats.Add(model.Name, model.ImageUrl, model.Description, ownerId);

            if (!success)
            {
                return this.BadRequest();
            }

            //this.TempData.AddSuccessMessage($"The cat {model.Name} was added successfully!");

            return this.RedirectToAction(nameof(All));
        }
    }
}