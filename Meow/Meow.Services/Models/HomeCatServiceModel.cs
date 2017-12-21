namespace Meow.Services.Models
{
    using AutoMapper;
    using Core.Mapping;
    using Data.Models;
    using Meow.Data.Models.Enums;

    public class HomeCatServiceModel : IMapFrom<HomeCat>, IHaveCustomMapping
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public byte[] Image { get; set; }

        public string Description { get; set; }

        public string Location { get; set; }

        public Gender Gender { get; set; }

        public string OwnerId { get; set; }

        public string Owner { get; set; }
    
        public void ConfigureMapping(Profile mapper)
            => mapper
                .CreateMap<HomeCat, HomeCatServiceModel>()
                .ForMember(c => c.Owner, cfg => cfg.MapFrom(c => c.Owner.UserName));
    }
}