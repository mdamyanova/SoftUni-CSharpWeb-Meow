namespace Meow.Services.Admin.Contracts
{
    using Services.Models;
    using System.Collections.Generic;

    public interface IAdminCatService
    {
        IEnumerable<HomeCatListingServiceModel> All();
    }
}