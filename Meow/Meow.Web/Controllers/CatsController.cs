namespace Meow.Web.Controllers
{
    using Data.Models;
    using Meow.Web.Infrastructure.Extensions;
    using Meow.Web.Models;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
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

        // authorize ? 
        public IActionResult Details(int id)
        {
            var cat = this.homeCats.ById(id);
            return this.ViewOrNotFound(cat);      
        }

        [Authorize]
        public IActionResult Add()
        {
            return this.View();
        }

        [HttpPost]
        [Authorize]
        public IActionResult Add(HomeCatFormModel model)
        {
            var ownerId = this.userManager.GetUserId(User);

            var success = this.homeCats.Add(
                model.Name, model.Age, model.ImageUrl, model.Description, model.Gender, ownerId);

            if (!success)
            {
                return this.BadRequest();
            }

            //this.TempData.AddSuccessMessage($"The cat {model.Name} was added successfully!");

            return this.RedirectToAction(nameof(All));
        }

        public IActionResult Edit(int id)
        {
            var homeCat = this.homeCats.ById(id);

            if (homeCat == null)
            {
                return this.NotFound();
            }

            return this.View(new HomeCatFormModel
            {
              Name = homeCat.Name,
              Age = homeCat.Age,
              ImageUrl = homeCat.ImageUrl,
              Description = homeCat.Description,
              Gender = homeCat.Gender
            });
        }

        [HttpPost]
        public IActionResult Edit(int id, HomeCatFormModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            var homeCatExists = this.homeCats.Exists(id);

            if (!homeCatExists)
            {
                return this.NotFound();
            }

            this.homeCats.Edit(
                id, model.Name, model.Age, model.ImageUrl, model.Description, model.Gender);

            return this.RedirectToAction(nameof(this.All));
        }
    }
}