namespace Meow.Services.Models
{
    using AutoMapper;
    using Core.Mapping;
    using Data.Models;

    public class HomeCatListingServiceModel : IMapFrom<HomeCat>, IHaveCustomMapping
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string ImageUrl { get; set; }

        public string Owner { get; set; }

        public void ConfigureMapping(Profile mapper)
            => mapper
                .CreateMap<HomeCat, HomeCatListingServiceModel>()
                .ForMember(c => c.Owner, cfg => cfg.MapFrom(c => c.Owner.UserName));
    }
}