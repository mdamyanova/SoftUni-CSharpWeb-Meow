namespace Meow.Services.Cats.Models
{
    using AutoMapper;
    using Core.Mapping;
    using Data.Models;

    public class AdoptionCatListingServiceModel : IMapFrom<AdoptionCat>, IHaveCustomMapping
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public byte[] Image { get; set; }

        public string Owner { get; set; }

        public void ConfigureMapping(Profile mapper)
            => mapper
                .CreateMap<AdoptionCat, AdoptionCatListingServiceModel>()
                .ForMember(c => c.Owner, cfg => cfg.MapFrom(c => c.Owner.UserName));
    }
}