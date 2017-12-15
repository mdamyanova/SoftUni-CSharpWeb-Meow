namespace Meow.Services.Models
{
    using Core.Mapping;
    using Data.Models;

    public class UserListingServiceModel : IMapFrom<User>
    {
        public string Id { get; set; }

        public string UserName { get; set; }

        public string Name { get; set; }

        public byte[] ProfilePhoto { get; set; }
    }
}