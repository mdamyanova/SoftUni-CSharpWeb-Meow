namespace Meow.Web.Areas.Volunteer.Controllers
{
    using Data.Models;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Models;
    using Services.Volunteer.Contracts;

    public class CatsController : BaseVolunteerController
    {
        private readonly UserManager<User> userManager;
        private readonly IAdoptionCatService adoptionCats;

        public CatsController(UserManager<User> userManager, IAdoptionCatService adoptionCats)
        {
            this.userManager = userManager;
            this.adoptionCats = adoptionCats;
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
            var ownerId = this.userManager.GetUserId(User);

            var success = this.adoptionCats.Add(
                model.Name, model.Age, model.Image, model.Description, model.Gender, ownerId);

            if (!success)
            {
                return this.BadRequest();
            }

            //this.TempData.AddSuccessMessage($"The cat {model.Name} was added successfully!");

            return RedirectToAction("Adopted", "Cats", new { area = "" });
        }

        public IActionResult Edit(int id)
        {
            var adoptionCat = this.adoptionCats.ById(id);

            if (adoptionCat == null)
            {
                return this.NotFound();
            }

            if (User.Identity.Name != adoptionCat.Owner)
            {
                // user doesn't have the rights
                return RedirectToAction("Adopted", "Cats", new { area = "" });
            }

            return this.View(new AdoptionCatFormModel
            {
                Name = adoptionCat.Name,
                Age = adoptionCat.Age,
                Description = adoptionCat.Description,
                Gender = adoptionCat.Gender
            });
        }

        [HttpPost]
        public IActionResult Edit(int id, AdoptionCatFormModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            var adoptionCatExists = this.adoptionCats.Exists(id);

            if (!adoptionCatExists)
            {
                return this.NotFound();
            }

            this.adoptionCats.Edit(
                model.Id, model.Name, model.Age, model.Image, model.Description, model.Gender, "");

            return RedirectToAction("Adopted", "Cats", new { area = "" });
        }
        
        public IActionResult Delete(int id)
        {
            // todo: check if user has rights to delete

            var adoptionCat = this.adoptionCats.ById(id);

            if (adoptionCat == null)
            {
                return this.NotFound();
            }

            if (User.Identity.Name != adoptionCat.Owner)
            {
                // user doesn't have the rights
                return RedirectToAction("Adopted", "Cats", new { area = "" });
            }

            return this.View(new AdoptionCatFormModel
            {
                Name = adoptionCat.Name,
                Age = adoptionCat.Age,
                
                Description = adoptionCat.Description,
                Gender = adoptionCat.Gender
            });
        }

        [HttpPost]
        public IActionResult Delete(int id, AdoptionCatFormModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            var adoptionCatExists = this.adoptionCats.Exists(id);

            if (!adoptionCatExists)
            {
                return this.NotFound();
            }

            var result = this.adoptionCats.Remove(id);

            // todo
            return RedirectToAction("Adopted", "Cats", new { area = "" });
        }

    }
}