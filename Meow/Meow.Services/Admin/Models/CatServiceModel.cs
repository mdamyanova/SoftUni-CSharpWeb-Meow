namespace Meow.Services.Admin.Models
{
    using AutoMapper;
    using Core.Mapping;
    using Data.Models;

    public class CatServiceModel : IMapFrom<Cat>, IHaveCustomMapping
    {
        public string Name { get; set; }

        public string ImageUrl { get; set; }

        public string Description { get; set; }

        public string Location { get; set; }
        
        public bool IsAdopted { get; set; }

        public string Owner { get; set; }
    
        public void ConfigureMapping(Profile mapper)
            => mapper
                .CreateMap<Cat, CatServiceModel>()
                .ForMember(c => c.Owner, cfg => cfg.MapFrom(c => c.Owner.UserName));
    }
}