namespace Meow.Web.Controllers
{
    using Data.Models;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Services.Contracts;
    using System.Threading.Tasks;

    public class UsersController : Controller
    {
        private readonly IUserService users;
        private readonly UserManager<User> userManager;

        public UsersController(IUserService users, UserManager<User> userManager)
        {
            this.users = users;
            this.userManager = userManager;
        }

        [Authorize]
        public IActionResult All()
        {
            var model = this.users.All();

            return this.View(model);
        }

        public async Task<IActionResult> Profile(string username)
        {
            var user = await this.userManager.FindByNameAsync(username);

            if (user == null)
            {
                return this.NotFound();
            }

            var model = await this.users.ProfileAsync(user.Id);

            return View(model);
        }

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
    }
}