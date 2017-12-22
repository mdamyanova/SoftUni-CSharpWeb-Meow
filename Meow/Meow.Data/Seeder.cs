﻿namespace Meow.Data
{
    using Core;
    using Models;
    using Models.Enums;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;

    public class Seeder
    {
        private MeowDbContext db;

        public Seeder(MeowDbContext db)
        {
            this.db = db;
        }

        public async Task Seed()
        {  
            var admin = this.db.Users.FirstOrDefault(u => u.UserName == WebConstants.AdministratorUsername);
            var mirelka = this.db.Users.FirstOrDefault(u => u.UserName == "mirelka");

            var defaultImage = File.ReadAllBytes("../Meow.Web/wwwroot/images/default-cat.png");
            var mirelkaPath = "../Meow.Web/wwwroot/images/mirelka/";

            var homeCats = new List<HomeCat>
            {
                new HomeCat()
                {
                    Name = "Samuil",
                    Age = 1,
                    Image = defaultImage,
                    Description = "Hi, this is Samuil.",
                    Location = "Plovdiv",
                    Gender = Gender.Male,
                    OwnerId = admin.Id,
                    Owner = admin
                },
                new HomeCat()
                {
                    Name = "Cezarcho",
                    Age = 2,
                    Image = defaultImage,
                    Description = "Hi, this is Cezarcho.",
                    Location = "Sofia",
                    Gender = Gender.Male,
                    OwnerId = admin.Id,
                    Owner = admin
                },
                new HomeCat()
                {
                    Name = "Siika",
                    Age = 3,
                    Image = defaultImage,
                    Description = "Hi, this is Siika.",
                    Location = "Sofia",
                    Gender = Gender.Female,
                    OwnerId = admin.Id,
                    Owner = admin
                },
                new HomeCat()
                {
                    Name = "Anastasiya",
                    Age = 7,
                    Image = defaultImage,
                    Description = "Hi, this is a cute cat lqlqlq.",
                    Location = "Sofia",
                    Gender = Gender.Female,
                    OwnerId = admin.Id,
                    Owner = admin
                },
                new HomeCat()
                {
                    Name = "Sa6ko",
                    Age = 9,
                    Image = defaultImage,
                    Description = "I'm Sa6ko.",
                    Location = "Sofia",
                    Gender = Gender.Male,
                    OwnerId = admin.Id,
                    Owner = admin
                },
                new HomeCat()
                {
                    Name = "Katty",
                    Age = 2,
                    Image = defaultImage,
                    Description = "Hi, this is Katty. I'm a sweet cat born in Sofia. I have a cute owner and even cuter paws.",
                    Location = "Sofia",
                    Gender = Gender.Male,
                    OwnerId = admin.Id,
                    Owner = admin
                },
                new HomeCat()
                {
                    Name = "Shishi",
                    Age = 3,
                    Image = File.ReadAllBytes(mirelkaPath + "shishi.jpg"),
                    Description = "Hi, this is Shishi.",
                    Location = "Sofia",
                    Gender = Gender.Female,
                    OwnerId = mirelka.Id,
                    Owner = mirelka
                },
                new HomeCat()
                {
                    Name = "Syselcho",
                    Age = 2,
                    Image = File.ReadAllBytes(mirelkaPath + "syselcho.jpg"),
                    Description = "Hi, this is Syselcho.",
                    Location = "Sofia",
                    Gender = Gender.Male,
                    OwnerId = mirelka.Id,
                    Owner = mirelka
                },
                new HomeCat()
                {
                    Name = "Hapeshtoto zverche",
                    Age = 2,
                    Image = File.ReadAllBytes(mirelkaPath + "zvyar.jpg"),
                    Description = "Hi, this is hapeshtoto zverche.",
                    Location = "Sofia",
                    Gender = Gender.Male,
                    OwnerId = mirelka.Id,
                    Owner = mirelka
                },
                new HomeCat()
                {
                    Name = "Bez ime",
                    Age = 2,
                    Image = File.ReadAllBytes(mirelkaPath + "bez-ime.jpg"),
                    Description = "Hi, this cat is without name.",
                    Location = "Sofia",
                    Gender = Gender.Male,
                    OwnerId = mirelka.Id,
                    Owner = mirelka
                }
            };
       
            // add some home cats to admin, sorry
            if (!this.db.HomeCats.Any())
            {
                this.db.HomeCats.AddRange(homeCats);
                await this.db.SaveChangesAsync();
            }

            // add iCatRescue Volunteer
            var volunteer = this.db.Users.FirstOrDefault(u => u.UserName == WebConstants.VolunteerRole);
            var adoptionCatsPath = "../Meow.Web/wwwroot/images/iCatRescue/";

            var adoptionCats = new List<AdoptionCat>
            {
                new AdoptionCat
                {
                    Name = "Bony",
                    Age = 1,
                    Image = File.ReadAllBytes(adoptionCatsPath + "bony.jpg"),
                    Description = WebConstants.Bony,
                    Gender = Gender.Female,
                    OwnerId = volunteer.Id,
                    Location = "Sofia"
                },
                new AdoptionCat
                {
                    Name = "Goshi",
                    Age = 1,
                    Image = File.ReadAllBytes(adoptionCatsPath + "goshi.jpg"),
                    Description = WebConstants.Goshi,
                    Gender = Gender.Male,
                    OwnerId = volunteer.Id,
                    Location = "Sofia"
                },
                new AdoptionCat
                {
                    Name = "Kivi",
                    Age = 1,
                    Image = File.ReadAllBytes(adoptionCatsPath + "kivi.jpg"),
                    Description = WebConstants.Kivi,
                    Gender = Gender.Male,
                    OwnerId = volunteer.Id,
                    Location = "Sofia"
                },
                new AdoptionCat
                {
                    Name = "Leya",
                    Age = 1,
                    Image = File.ReadAllBytes(adoptionCatsPath + "leya.jpg"),
                    Description = WebConstants.Leya,
                    Gender = Gender.Female,
                    OwnerId = volunteer.Id,
                    Location = "Sofia"
                },
                new AdoptionCat
                {
                    Name = "Maraya",
                    Age = 1,
                    Image = File.ReadAllBytes(adoptionCatsPath + "maraya.jpg"),
                    Description = WebConstants.Maraya,
                    Gender = Gender.Female,
                    OwnerId = volunteer.Id,
                    Location = "Sofia"
                },
                new AdoptionCat
                {
                    Name = "Oreo",
                    Age = 1,
                    Image = File.ReadAllBytes(adoptionCatsPath + "oreo.jpg"),
                    Description = WebConstants.Oreo,
                    Gender = Gender.Male,
                    OwnerId = volunteer.Id,
                    Location = "Sofia"
                }
            };

            // add some adoption cats
            if (!this.db.AdoptionCats.Any())
            {
                this.db.AdoptionCats.AddRange(adoptionCats);
                await this.db.SaveChangesAsync();
            }    
        }
    }
}