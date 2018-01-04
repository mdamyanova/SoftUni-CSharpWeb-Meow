namespace Meow.Services.Contracts
{
    using Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Volunteer.Models;

    public interface IUserService
    {
        bool Exists(string id);
        
        IEnumerable<UserListingServiceModel> All();

        Task<UserProfileServiceModel> ProfileAsync(string username, string role);

        Task<IEnumerable<HomeCatListingServiceModel>> HomeCatsAsync(string id);

        Task<IEnumerable<AdoptionCatListingServiceModel>> AdoptedCatsAsync(string id);

        bool Remove(string id);
    }
}