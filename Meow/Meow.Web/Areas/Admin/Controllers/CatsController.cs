namespace Meow.Web.Areas.Admin.Controllers
{
    using Services.Admin.Contracts;
    using Microsoft.AspNetCore.Mvc;

    public class CatsController : BaseAdminController
    {
        private readonly IAdminCatService cats;

        public CatsController(
            IAdminCatService cats)
        {
            this.cats = cats;
        }

        public IActionResult Manage()
        {
            var model = this.cats.All();

            return this.View(model);
        }
    }
}