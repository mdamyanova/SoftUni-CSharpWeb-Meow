namespace Meow.Services.Admin.Models
{
    using Core.Mapping;
    using Data.Models;

    public class AdminUsersListingServiceModel : IMapFrom<User>
    {
        public string Id { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }
    }
}