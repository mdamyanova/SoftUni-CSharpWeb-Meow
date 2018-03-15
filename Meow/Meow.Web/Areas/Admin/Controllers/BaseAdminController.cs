namespace Meow.Web.Areas.Admin.Controllers
{
    using Core;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Area(WebConstants.AdministratorArea)]
    [Authorize(Roles = WebConstants.AdministratorRole)]
    public class BaseAdminController : Controller
    {
    }
}