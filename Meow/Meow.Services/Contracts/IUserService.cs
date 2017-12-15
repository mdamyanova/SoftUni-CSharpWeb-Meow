namespace Meow.Services.Contracts
{
    using Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IUserService
    {
        IEnumerable<UserListingServiceModel> All();

        Task<UserProfileServiceModel> ProfileAsync(string username);
    }
}