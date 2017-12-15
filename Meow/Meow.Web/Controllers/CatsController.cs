namespace Meow.Web.Controllers
{
    using System;
    using Data.Models;
    using Infrastructure.Extensions;
    using Meow.Web.Models.Cats;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Models;
    using Services.Contracts;

    public class CatsController : Controller
    {
        private readonly UserManager<User> userManager;
        private readonly IHomeCatService homeCats;
        private readonly IAdoptionCatService adoptionCats;

        public CatsController(UserManager<User> userManager, IHomeCatService homeCats, IAdoptionCatService adoptionCats)
        {
            this.userManager = userManager;
            this.homeCats = homeCats;
            this.adoptionCats = adoptionCats;
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

            // if model is empty show message no cats ? 

            return this.View(model);
        }

        [Authorize]
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

        [Authorize]
        public IActionResult Edit(int id)
        {        
            var homeCat = this.homeCats.ById(id);

            if (homeCat == null)
            {
                return this.NotFound();
            }

            if (User.Identity.Name != homeCat.Owner)
            {
                // user doesn't have the rights
                return this.RedirectToAction(nameof(this.All));
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

        [Authorize]
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

        [Authorize]
        public IActionResult Delete(int id)
        {
            // todo: check if user has rights to delete

            var homeCat = this.homeCats.ById(id);

            if (homeCat == null)
            {
                return this.NotFound();
            }

            if (User.Identity.Name != homeCat.Owner)
            {
                // user doesn't have the rights
                return this.RedirectToAction(nameof(this.All));
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

        [Authorize]
        [HttpPost]
        public IActionResult Delete(int id, HomeCatFormModel model)
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

            var result = this.homeCats.Remove(id);

            // todo

            return this.RedirectToAction(nameof(this.All));
        }

        [Authorize]
        public IActionResult Request(int id)
        {
            var adoptionCat = this.adoptionCats.ById(id);

            if (adoptionCat == null)
            {
                return this.NotFound();
            }

            return this.View(new AdoptionCatDetailsViewModel
            {
                Name = adoptionCat.Name,
                Age = adoptionCat.Age,
                ImageUrl = adoptionCat.ImageUrl,
                Description = adoptionCat.Description,
                Gender = adoptionCat.Gender,
                IsAdopted = adoptionCat.IsAdopted
            });
        }

        [Authorize]
        [HttpPost]
        public IActionResult Request(int id, AdoptionCatDetailsViewModel model)
        {
            return null;
        }
    }
}