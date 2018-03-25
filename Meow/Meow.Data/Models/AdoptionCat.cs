using System.Collections.Generic;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Meow.Data.Models
{
    public class AdoptionCat : Cat
    {
        public bool IsAdopted { get; set; }

        public bool IsRequested { get; set; }

        public string RequestedOwnerId { get; set; }

        public List<AdoptionCatUser> Adopters { get; set; } = new List<AdoptionCatUser>();
    }
}