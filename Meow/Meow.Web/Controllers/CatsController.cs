namespace Meow.Web.Controllers
{
    using Core;
    using Data.Models;
    using Infrastructure.Extensions;
    using Meow.Web.Models.Cats;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Models;
    using Services.Contracts;
    using Services.Volunteer.Contracts;

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
        [Authorize]
        public IActionResult All()
        {
            var model = this.homeCats.All();

            return this.View(model);
        }

        // all adoption cats 
        public IActionResult Adoption()
        {
            var model = this.adoptionCats.All();
           
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

        [Authorize]
        [HttpPost]
        public IActionResult Add(HomeCatFormModel model)
        {
            var ownerId = this.userManager.GetUserId(User);

            var success = this.homeCats.Add(
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
            var cat = this.homeCats.ById(id);

            if (cat == null)
            {
                return this.NotFound();
            }

            if (User.Identity.Name != cat.Owner 
                && User.Identity.Name != WebConstants.AdministratorUsername)
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

            var catExists = this.homeCats.Exists(id);

            if (!catExists)
            {
                return this.NotFound();
            }

            this.homeCats.Edit(id, model.Name, model.Age, model.Description, model.Image, model.Gender);

            return this.RedirectToAction(nameof(this.All));
        }

        [Authorize]
        public IActionResult Delete(int id)
        {
            var cat = this.homeCats.ById(id);

            if (cat == null)
            {
                return this.NotFound();
            }

            if (User.Identity.Name != cat.Owner
                && User.Identity.Name != WebConstants.AdministratorUsername)
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
            var catExists = this.homeCats.Exists(id);

            if (!catExists)
            {
                return this.NotFound();
            }

            var result = this.homeCats.Remove(id);

            return this.RedirectToAction(nameof(this.All));
        }

        [Authorize]
        public IActionResult Adopt(int id)
        {
            var cat = this.adoptionCats.ById(id);

            if (cat == null)
            {
                return this.NotFound();
            }

            return this.View(new AdoptionCatDetailsViewModel
            {
                Id = cat.Id,
                Name = cat.Name,
                Age = cat.Age,
                Image = cat.Image,
                Description = cat.Description,
                Location = cat.Location,
                Gender = cat.Gender,
                Owner = cat.Owner,
                IsAdopted = cat.IsAdopted
            });
        }

        [Authorize]
        public new IActionResult Request(int id)
        {
            var cat = this.adoptionCats.ById(id);

            if (cat == null)
            {
                return this.NotFound();
            }

            return this.View(new RequestAdoptionViewModel
            {
               Name = cat.Name,
               Username = User.Identity.Name
            });
        }

        [Authorize]
        [HttpPost]
        public new IActionResult Request(int id, RequestAdoptionViewModel model)
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

            var success = this.adoptionCats.Adopt(id, User.Identity.Name);

            if (!success)
            {
                return this.BadRequest();
            }

            this.TempData.AddSuccessMessage($"The cat {model.Name} was requested for adoption successfully!");

            return this.RedirectToAction(nameof(Adoption));
        }
    }
}