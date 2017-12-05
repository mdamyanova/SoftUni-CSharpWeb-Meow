namespace Meow.Web.Controllers
{
    using Data.Models;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class UsersController : Controller
    {
        //private readonly IUserService users;
        private readonly UserManager<User> userManager;

        public UsersController(IUserService users, UserManager<User> userManager)
        {
            this.users = users;
            this.userManager = userManager;
        }

        public IActionResult Profile(string username)
        {
            var user = this.userManager.FindByNameAsync(username);

            if (user == null)
            {
                return NotFound();
            }

            var profile = await this.users.ProfileAsync(user.Id);

            return View(profile);
        }
    }
}