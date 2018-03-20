namespace Meow.Web.Controllers
{
    using Core;
    using Data.Models;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Models;
    using Services.Contracts;
    using System.Linq;
    using System.Threading.Tasks;

    public class UsersController : Controller
    {
        private readonly IUserService users;
        private readonly UserManager<User> userManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public UsersController(IUserService users, UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            this.users = users;
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        [Authorize]
        public IActionResult All()
        {
            var model = this.users.All();

            return this.View(model);
        }

        [Authorize]
        public async Task<IActionResult> Profile(string username)
        {
            var user = await this.userManager.FindByNameAsync(username);

            if (user == null)
            {
                return this.NotFound();
            }
            var roles = await this.userManager.GetRolesAsync(user);
            //var userRole = "Normal";

            // we can use this at this moment, because I have only one multiple roles - admin :)
            //if (role != null && role.Count() != 0)
            //{
            //    userRole = role[0];
            //}

            var model = await this.users.ProfileAsync(user.Id);
            model.UserRoles = roles;

            return View(model);
        }

        [Authorize]
        public async Task<IActionResult> HomeCats(string username)
        {
            var user = await this.userManager.FindByNameAsync(username);

            if (user == null)
            {
                return this.NotFound();
            }

            var model = await this.users.HomeCatsAsync(user.Id);

            return View(model);
        }

        [Authorize]
        public async Task<IActionResult> AdoptedCats(string username)
        {
            var user = await this.userManager.FindByNameAsync(username);

            if (user == null)
            {
                return this.NotFound();
            }

            var model = await this.users.AdoptedCatsAsync(user.Id);

            return View(model);
        }

        public IActionResult Edit(string username)
        {
            var task = this.userManager.FindByNameAsync(username);
            var user = task.Result;

            if (user == null)
            {
                return this.NotFound();
            }

            if (User.Identity.Name != user.UserName &&
                !this.User.IsInRole(WebConstants.AdministratorRole))
            {
                // user doesn't have the rights
                return RedirectToAction("All");
            }

            return this.View(new UserFormModel
            {
                Username = user.UserName,
                Name = user.Name,
                Location = user.Location,
                Birthdate = user.Birthdate,
                Gender = user.Gender
            });
        }

        [HttpPost]
        public IActionResult Edit(string username, UserFormModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            var user = this.userManager.FindByNameAsync(username);
            var userExists = this.users.Exists(user.Result.Id);

            if (!userExists)
            {
                return this.NotFound();
            }

            this.users.Edit(model.Username, model.Name, model.Location, model.Birthdate, model.Gender, model.Image);

            return RedirectToAction("All");
        }

        [Authorize]
        public async Task<IActionResult> Delete(string username)
        {
            var user = await this.userManager.FindByNameAsync(username);

            if (user == null)
            {
                return this.NotFound();
            }

            // we won't delete the admin and volunteer
            if (user.UserName == WebConstants.AdministratorUsername
                || user.UserName == WebConstants.VolunteerUsername)
            {
                return this.RedirectToAction(nameof(All));
            }
      
            if (User.Identity.Name != user.UserName
                && User.Identity.Name != WebConstants.AdministratorUsername)
            {
                // user doesn't have the rights
                return this.RedirectToAction(nameof(this.All));
            }

            return this.View(model:username);
        }

        [Authorize]
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> ConfirmDelete(string username)
        {       
            var user = await this.userManager.FindByNameAsync(username);
            var userExists = this.users.Exists(user.Id);

            if (!userExists)
            {
                return this.NotFound();
            }

            var result = this.users.Remove(user.Id);

            return this.RedirectToAction(nameof(this.All));
        }
    }
}