namespace Meow.Web.Areas.Cats.Controllers
{
    using Services.Cats.Contracts;
    using Microsoft.AspNetCore.Mvc;
    using Infrastructure.Extensions;
    using Microsoft.AspNetCore.Authorization;
    using Meow.Data.Models;
    using Meow.Web.Areas.Cats.Models.HomeCats;
    using Microsoft.AspNetCore.Identity;

    using static Core.WebConstants;

    [Area(CatsArea)]
    [Authorize]
    public class HomeCatsController : Controller
    {
        private readonly UserManager<User> userManager;
        private readonly IHomeCatService cats;

        public HomeCatsController(IHomeCatService cats, UserManager<User> userManager)
        {
            this.cats = cats;
            this.userManager = userManager;
        }

        // all home cats
        [AllowAnonymous]
        public IActionResult All()
        {
            var model = this.cats.All();

            return this.View(model);
        }

        // details about home cat
        public IActionResult Details(int id)
        {
            var cat = this.cats.ById(id);

            return this.ViewOrNotFound(cat);
        }

        public IActionResult Add()
        {
            return this.View();
        }

        [Authorize]
        [HttpPost]
        public IActionResult Add(HomeCatFormModel model)
        {
            var ownerId = this.userManager.GetUserId(User);

            var success = this.cats.Add(
                model.Name, model.Image, model.Age, model.Description, model.Gender, ownerId);

            if (!success)
            {
                return this.BadRequest();
            }

            //this.TempData.AddSuccessMessage($"The cat {model.Name} was added successfully!");

            return this.RedirectToAction(nameof(All));
        }

        [Authorize]
        public IActionResult Edit(int id)
        {
            var cat = this.cats.ById(id);

            if (cat == null)
            {
                return this.NotFound();
            }

            if (User.Identity.Name != cat.Owner
                && User.Identity.Name != AdministratorUsername)
            {
                // user doesn't have the rights
                return this.RedirectToAction(nameof(this.All));
            }

            return this.View(new HomeCatFormModel
            {
                Name = cat.Name,
                Age = cat.Age,
                Description = cat.Description,
                Gender = cat.Gender
            });
        }

        [Authorize]
        [HttpPost]
        public IActionResult Edit(int id, HomeCatFormModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            var catExists = this.cats.Exists(id);

            if (!catExists)
            {
                return this.NotFound();
            }

            this.cats.Edit(id, model.Name, model.Age, model.Description, model.Image, model.Gender);

            return this.RedirectToAction(nameof(this.All));
        }

        [Authorize]
        public IActionResult Delete(int id)
        {
            var cat = this.cats.ById(id);

            if (cat == null)
            {
                return this.NotFound();
            }

            if (User.Identity.Name != cat.Owner
                && User.Identity.Name != AdministratorUsername)
            {
                // user doesn't have the rights
                return this.RedirectToAction(nameof(this.All));
            }

            return this.View(new HomeCatDeleteFormModel
            {
                Name = cat.Name,
                Age = cat.Age
            });
        }

        [Authorize]
        [HttpPost, ActionName("Delete")]
        public IActionResult ConfirmDelete(int id)
        {
            var catExists = this.cats.Exists(id);

            if (!catExists)
            {
                return this.RedirectToAction(nameof(this.All));
            }

            var result = this.cats.Remove(id);

            return this.RedirectToAction(nameof(this.All));
        }

        public IActionResult Manage()
        {
            var model = this.cats.All();

            return this.View(model);
        }
    }
}
