namespace Meow.Web.Areas.Volunteer.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Area(WebConstants.AdminArea)]
    [Authorize(Roles = WebConstants.VolunteerRole)]
    [Authorize(Roles = WebConstants.AdministratorRole)]
    public class BaseVolunteerController : Controller
    {
    }
}