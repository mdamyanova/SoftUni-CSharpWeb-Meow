namespace Meow.Web.Areas.Admin.Controllers
{
    using Meow.Data.Models;
    using Meow.Services.Admin.Contracts;
    using Meow.Web.Areas.Admin.Models;
    using Meow.Web.Areas.Admin.Models.Cats;
    using Meow.Web.Controllers;
    using Meow.Web.Infrastructure.Filters;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class CatsController : BaseAdminController
    {
        private readonly UserManager<User> userManager;
        private readonly ICatService cats;

        public CatsController(UserManager<User> userManager, ICatService cats)
        {
            this.userManager = userManager;
            this.cats = cats;
        }

        public IActionResult Add()
        {
            return this.View();
        }

        [HttpPost]
        [ValidateModelState]
        public IActionResult Add(AddCatFormModel model)
        {
            var userId = this.userManager.GetUserId(User);

            this.cats.Add(model.Name, model.ImageUrl, model.Description, model.Location, userId);

            //this.TempData.AddSuccessMessage($"The cat {model.Name} was added successfully!");

            // get out from the area 
            return this.RedirectToAction(nameof(HomeController.Index), "Home", new { area = string.Empty });
        }
    }
}