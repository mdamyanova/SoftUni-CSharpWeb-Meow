namespace Meow.Services.Contracts
{
    using Admin.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IAdminUserService
    {
        IEnumerable<AdminUsersListingServiceModel> All();
    }
}