namespace Meow.Web.Areas.Cats.Controllers
{
    using Core;
    using Data.Models;
    using Infrastructure.Extensions;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Models.AdoptionCats;
    using Services.Cats.Contracts;

    [Area(WebConstants.CatsArea)]
    [Authorize]
    public class AdoptionCatsController : Controller
    {
        private readonly UserManager<User> userManager;
        private readonly IAdoptionCatService adoptionCats;

        public AdoptionCatsController(UserManager<User> userManager, IAdoptionCatService adoptionCats)
        {
            this.userManager = userManager;
            this.adoptionCats = adoptionCats;
        }

        // all adoption cats 
        public IActionResult Adoption()
        {
            var model = this.adoptionCats.All();

            return this.View(model);
        }

        // details about adoption cat
        public IActionResult Adopt(int id)
        {
            var cat = this.adoptionCats.ById(id);

            return this.ViewOrNotFound(cat);
        }

        public IActionResult Manage()
        {
            var model = this.adoptionCats.All();

            return this.View(model);
        }

        public IActionResult Add()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Add(AdoptionCatFormModel model)
        {
            var success = this.adoptionCats.Add(
                model.Name, model.Image, model.Age, model.Location, model.Description, model.Gender);

            if (!success)
            {
                return this.BadRequest();
            }

            this.TempData.AddSuccessMessage($"The cat {model.Name} was added successfully!");

            return RedirectToAction("Adoption", "Cats", new { area = "" });
        }

        public IActionResult Edit(int id)
        {
            var cat = this.adoptionCats.ById(id);

            if (cat == null)
            {
                return this.NotFound();
            }

            if (User.Identity.Name != cat.Owner &&
                !this.User.IsInRole(WebConstants.AdministratorRole))
            {
                // user doesn't have the rights
                return RedirectToAction("Adoption", "Cats", new { area = "" });
            }

            return this.View(new AdoptionCatFormModel
            {
                Name = cat.Name,
                Age = cat.Age,
                Description = cat.Description,
                Gender = cat.Gender
            });
        }

        [HttpPost]
        public IActionResult Edit(int id, AdoptionCatFormModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            var catExists = this.adoptionCats.Exists(id);

            if (!catExists)
            {
                return this.NotFound();
            }

            this.adoptionCats.Edit(
                model.Id, model.Name, model.Age, model.Image, model.Description, model.Gender, "");

            return RedirectToAction("Adoption", "Cats", new { area = "" });
        }

        [Authorize]
        public IActionResult Delete(int id)
        {
            var cat = this.adoptionCats.ById(id);

            if (cat == null)
            {
                return this.NotFound();
            }

            if (User.Identity.Name != cat.Owner
                && User.Identity.Name != WebConstants.AdministratorUsername)
            {
                // user doesn't have the rights
                return RedirectToAction("Adoption", "Cats", new { area = "" });
            }

            return this.View(new AdoptionCatFormModel
            {
                Name = cat.Name,
                Age = cat.Age,
                Description = cat.Description,
                Gender = cat.Gender
            });
        }

        [Authorize]
        [HttpPost, ActionName("Delete")]
        public IActionResult ConfirmDelete(int id, AdoptionCatFormModel model)
        {
            var catExists = this.adoptionCats.Exists(id);

            if (!catExists)
            {
                return RedirectToAction("Adoption", "Cats", new { area = "" });
            }

            var result = this.adoptionCats.Remove(id);

            return RedirectToAction("Adoption", "Cats", new { area = "" });
        }

        public IActionResult Requests()
        {
            var model = this.adoptionCats.Requested();

            return this.View(model);
        }

        public IActionResult Give(int id)
        {
            var cat = this.adoptionCats.ById(id);

            if (cat == null)
            {
                return this.NotFound();
            }

            if (User.Identity.Name != cat.Owner
                && User.Identity.Name != WebConstants.AdministratorUsername)
            {
                // user doesn't have the rights
                return RedirectToAction("Adoption", "Cats", new { area = "" });
            }

            var success = this.adoptionCats.Give(id);

            return this.RedirectToAction(nameof(Manage));
        }

        [Authorize]
        [HttpPost, ActionName("Request")]
        public IActionResult ConfirmRequest(int id)
        {
            var catExists = this.adoptionCats.Exists(id);

            if (!catExists)
            {
                return this.NotFound();
            }

            var success = this.adoptionCats.Adopt(id, User.Identity.Name);

            if (!success)
            {
                return this.BadRequest();
            }

            return this.RedirectToAction(nameof(Adoption));
        }
    }
}