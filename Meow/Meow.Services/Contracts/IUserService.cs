namespace Meow.Services.Contracts
{
    using Meow.Services.Volunteer.Models;
    using Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IUserService
    {
        bool Exists(string id);

        IEnumerable<UserListingServiceModel> All();

        Task<UserProfileServiceModel> ProfileAsync(string username);

        Task<IEnumerable<HomeCatListingServiceModel>> HomeCatsAsync(string id);

        Task<IEnumerable<AdoptionCatListingServiceModel>> AdoptedCatsAsync(string id);
    }
}