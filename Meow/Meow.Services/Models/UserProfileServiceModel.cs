namespace Meow.Services.Models
{
    using Core.Mapping;
    using Data.Models;

    public class UserProfileServiceModel : IMapFrom<User>
    {
        public string Username { get; set; }

        public string Name { get; set; }
  
        // todo
    }
}