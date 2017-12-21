namespace Meow.Services.Volunteer.Models
{
    using AutoMapper;
    using Core.Mapping;
    using Data.Models;
    using Data.Models.Enums;

    public class AdoptionCatServiceModel : IMapFrom<AdoptionCat>, IHaveCustomMapping
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public byte[] Image { get; set; }

        public string Description { get; set; }

        public string Location { get; set; }

        public Gender Gender { get; set; }

        public bool IsAdopted { get; set; }

        public string OwnerId { get; set; }

        public string Owner { get; set; }

        public void ConfigureMapping(Profile mapper)
            => mapper
                .CreateMap<AdoptionCat, AdoptionCatServiceModel>()
                .ForMember(c => c.Owner, cfg => cfg.MapFrom(c => c.Owner.UserName));
    }
}