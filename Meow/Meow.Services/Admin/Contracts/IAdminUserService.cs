namespace Meow.Services.Contracts
{
    using Admin.Models;
    using System.Collections.Generic;

    public interface IAdminUserService
    {
        IEnumerable<AdminUsersListingServiceModel> All();
    }
}