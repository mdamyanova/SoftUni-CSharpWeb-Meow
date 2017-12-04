namespace Meow.Services.Models
{
    using AutoMapper;
    using Core.Mapping;
    using Data.Models;

    public class CatListingServiceModel : IMapFrom<HomeCat>, IHaveCustomMapping
    {
        public string Name { get; set; }

        public string ImageUrl { get; set; }

        public string Owner { get; set; }

        public void ConfigureMapping(Profile mapper)
            => mapper
                .CreateMap<HomeCat, CatListingServiceModel>()
                .ForMember(c => c.Owner, cfg => cfg.MapFrom(c => c.Owner.UserName));
    }
}