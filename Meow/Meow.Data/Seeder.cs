namespace Meow.Data
{
    using Core;
    using Models;
    using Models.Enums;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
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
            var web = new WebClient();

            var admin = this.db.Users.FirstOrDefault(u => u.UserName == WebConstants.AdministratorUsername);
            var mirelka = this.db.Users.FirstOrDefault(u => u.UserName == "mirelka");
            var kalincho = this.db.Users.FirstOrDefault(u => u.UserName == "DESKTOP-0GN2RO6\\Dell");

            var defaultImage = web.DownloadData(WebConstants.DefaultCatUrl);

            var homeCats = new List<HomeCat>
            {
                new HomeCat
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
                new HomeCat
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
                new HomeCat
                {
                    Name = "Anastasiya",
                    Age = 3,
                    Image = web.DownloadData("https://cdn.shopify.com/s/files/1/0673/5325/files/LadyDinahs_Cat_Cafe_Alice-Block_2048x.jpg?v=1517059999"),
                    Description = "Hi, this is a cute cat lqlqlq.",
                    Location = "Plovdiv",
                    Gender = Gender.Female,
                    OwnerId = admin.Id,
                    Owner = admin
                },
                new HomeCat
                {
                    Name = "Sa6ko",
                    Age = 9,
                    Image = web.DownloadData("https://www.communitycatspodcast.com/wp-content/uploads/2017/05/GuestBlog1-750x750.jpeg"),
                    Description = "I'm Sa6ko.",
                    Location = "Sofia",
                    Gender = Gender.Male,
                    OwnerId = admin.Id,
                    Owner = admin
                },
                new HomeCat
                {
                    Name = "Katty",
                    Age = 1,
                    Image = web.DownloadData("http://www.buzzly.fr/uploads/thumb/960/phpM8gt3i.jpg"),
                    Description = "Hi, this is Katty. I'm a sweet cat born in Sofia. I have a cute owner and even cuter paws.",
                    Location = "Plovdiv",
                    Gender = Gender.Female,
                    OwnerId = admin.Id,
                    Owner = admin
                },
                new HomeCat
                {
                    Name = "Shishi",
                    Age = 2,
                    Image = web.DownloadData("https://scontent-sof1-1.xx.fbcdn.net/v/t1.0-0/s2048x2048/29186662_1720523821301884_8464872763612463104_o.jpg?oh=40461c7e1672cd9526037f452399ae2f&oe=5B359632"),
                    Description = "Hi, this is shishi.",
                    Location = "Sofia",
                    Gender = Gender.Male,
                    OwnerId = mirelka.Id,
                    Owner = mirelka
                },
                new HomeCat
                {
                    Name = "Syselcho",
                    Age = 2,
                    Image = web.DownloadData("https://scontent-sof1-1.xx.fbcdn.net/v/t1.0-0/29136082_1720523811301885_2063271412478509056_o.jpg?oh=21e2c1fa70e5004bf6b4ba2190bba0eb&oe=5B445FE1"),
                    Description = "Hi, this is Syselcho.",
                    Location = "Sofia",
                    Gender = Gender.Male,
                    OwnerId = mirelka.Id,
                    Owner = mirelka
                },
                new HomeCat
                {
                    Name = "Hapeshtoto zverche",
                    Age = 2,
                    Image = web.DownloadData("https://scontent-sof1-1.xx.fbcdn.net/v/t1.0-0/29177266_1720523801301886_5756089700943134720_o.jpg?oh=ae5dcd2503bf69e061e9379a192c6b95&oe=5B338DCB"),
                    Description = "Hi, this is hapeshtoto zverche.",
                    Location = "Sofia",
                    Gender = Gender.Male,
                    OwnerId = mirelka.Id,
                    Owner = mirelka
                },
                new HomeCat
                {
                    Name = "Bez ime",
                    Age = 2,
                    Image = web.DownloadData("https://scontent-sof1-1.xx.fbcdn.net/v/t1.0-0/s2048x2048/29216475_10208686503639562_5744457022540087296_o.jpg?oh=0ec34c02c39a1cf42969273b372dc292&oe=5B44DD94"),
                    Description = "Hi, this cat is without name.",
                    Location = "Sofia",
                    Gender = Gender.Male,
                    OwnerId = mirelka.Id,
                    Owner = mirelka
                },
                new HomeCat
                {
                    Name = "Oliver",
                    Age = 2,
                    Image = web.DownloadData("https://scontent-sof1-1.xx.fbcdn.net/v/t1.0-9/29136441_1720261874661412_8697264119625023488_n.jpg?oh=60d8c6ba8133afe8f3adc9282aa3ed85&oe=5B3C65FE"),
                    Description = "Hi, this is Oliver.",
                    Location = "Plovdiv",
                    Gender = Gender.Male,
                    OwnerId = admin.Id,
                    Owner = admin
                },
                new HomeCat
                {
                    Name = "Moshino",
                    Age = 2,
                    Image = web.DownloadData("http://i.dailymail.co.uk/i/pix/2017/07/16/09/42623C4B00000578-4700660-image-a-1_1500194523431.jpg"),
                    Description = "Здравейте, това е мъжкарят Мошино, той е много мил и игрив, но стане ли върпос за женската му, винаги се стига до котешка свада.",
                    Location = "Plovdiv",
                    Gender = Gender.Male,
                    OwnerId = admin.Id,
                    Owner = admin
                },
                new HomeCat
                {
                    Name = "Krivogledcho",
                    Age = 4,
                    Image = web.DownloadData("https://cdn.images.express.co.uk/img/dynamic/galleries/x701/177020.jpg"),
                    Description = "Здравейте, това е мъжкарят Мошино, той е много мил и игрив, но стане ли върпос за женската му, винаги се стига до котешка свада.",
                    Location = "Plovdiv",
                    Gender = Gender.Male,
                    OwnerId = admin.Id,
                    Owner = admin
                },
                new HomeCat
                {
                    Name = "Pisan",
                    Age = 1,
                    Image = web.DownloadData("http://a57.foxnews.com/images.foxnews.com/content/fox-news/lifestyle/2017/11/09/how-to-keep-cat-from-scratching-your-sofa-to-shreds/_jcr_content/par/featured_image/media-0.img.jpg/931/524/1510172827500.jpg?ve=1&tl=1&text=big-top-image"),
                    Description = "Hi this is pisan and he is very cute.",
                    Location = "Sofia",
                    Gender = Gender.Male,
                    OwnerId = admin.Id,
                    Owner = admin
                },
                new HomeCat
                {
                    Name = "Molly",
                    Age = 6,
                    Image = web.DownloadData("https://boygeniusreport.files.wordpress.com/2017/01/cat.jpg?quality=98&strip=all&w=782"),
                    Description = "Hi this is Molly and she is very aggressive.",
                    Location = "Sofia",
                    Gender = Gender.Female,
                    OwnerId = admin.Id,
                    Owner = admin
                },
                new HomeCat
                {
                    Name = "Niya",
                    Age = 3,
                    Image = web.DownloadData("http://purrtacular.com/wp-content/uploads/2016/08/fluffy-cats-10.jpg"),
                    Description = "Hi this is Niya and she love to eat Whiskas.",
                    Location = "Plovdiv",
                    Gender = Gender.Female,
                    OwnerId = admin.Id,
                    Owner = admin
                },
                new HomeCat
                {
                    Name = "Mustachko",
                    Age = 2,
                    Image = web.DownloadData("http://www.propaganda.co.uk/wp-content/uploads/2016/11/Cat-1.png"),
                    Description = "Hi this is Mustachko and he is having a moustache.",
                    Location = "Sofia",
                    Gender = Gender.Male,
                    OwnerId = admin.Id,
                    Owner = admin
                },
                new HomeCat
                {
                    Name = "Fintifliushko",
                    Age = 1,
                    Image = web.DownloadData("https://i.ytimg.com/vi/geqVuYmo8Y0/hqdefault.jpg"),
                    Description = "Hi this is Fintifliushko and he is the most lazy cat in the world.",
                    Location = "Sofia",
                    Gender = Gender.Male,
                    OwnerId = admin.Id,
                    Owner = admin
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

            var adoptionCats = new List<AdoptionCat>
            {
                new AdoptionCat
                {
                    Name = "Bonnie",
                    Age = 1,
                    Image = web.DownloadData("https://scontent-sof1-1.xx.fbcdn.net/v/t31.0-8/22424614_855095091325034_8692772344209827830_o.jpg?oh=66d5c0a012ddb9491b3bde3a265691eb&oe=5B357DCB"),
                    Description = WebConstants.Bonnie,
                    Gender = Gender.Female,
                    OwnerId = volunteer.Id,
                    Owner = volunteer,
                    Location = "Sofia"
                },
                new AdoptionCat
                {
                    Name = "Dobi",
                    Age = 1,
                    Image = web.DownloadData("https://scontent-sof1-1.xx.fbcdn.net/v/t31.0-8/28335890_928146187353257_5658026735196651433_o.jpg?oh=43b925dc2ea76dcf7e729159374283b5&oe=5B4E1F95"),
                    Description = WebConstants.Dobi,
                    Location = "Sofia",
                    Gender = Gender.Male,
                    OwnerId = volunteer.Id,
                    Owner = volunteer
                },
                new AdoptionCat
                {
                    Name = "Gizmo",
                    Age = 1,
                    Image = web.DownloadData("https://scontent-sof1-1.xx.fbcdn.net/v/t31.0-8/22339447_852467884921088_6320651926557237894_o.jpg?oh=e2907009cc418de0e2c4b2f80ba118b0&oe=5B0534E2"),
                    Description = WebConstants.Gizmo,
                    Location = "Sofia",
                    Gender = Gender.Male,
                    OwnerId = volunteer.Id,
                    Owner = volunteer
                },
                new AdoptionCat
                {
                    Name = "Anton",
                    Age = 1,
                    Image = web.DownloadData("https://scontent-sof1-1.xx.fbcdn.net/v/t31.0-8/27993084_923267477841128_313650127155735041_o.jpg?oh=24a91f4bff42d4399c2fa0c87801affd&oe=5B469EC4"),
                    Description = WebConstants.Anton,
                    Gender = Gender.Male,
                    OwnerId = volunteer.Id,
                    Owner = volunteer,
                    Location = "Sofia"
                },
                new AdoptionCat
                {
                    Name = "Dido",
                    Age = 2,
                    Image = web.DownloadData("https://scontent-sof1-1.xx.fbcdn.net/v/t31.0-8/27500456_913048358863040_1240387214817892750_o.jpg?oh=c3e89e3619b3540198a8b3ae36537ddb&oe=5B4C478F"),
                    Description = WebConstants.Dido,
                    Gender = Gender.Male,
                    OwnerId = volunteer.Id,
                    Owner = volunteer,
                    Location = "Sofia"
                },
                new AdoptionCat
                {
                    Name = "Grozilcho",
                    Age = 3,
                    Image = web.DownloadData("https://scontent-sof1-1.xx.fbcdn.net/v/t31.0-8/15578356_700031353498076_3706347799217960482_o.jpg?oh=443163140e7bc44a06c8fed4473cade7&oe=5B4A77DB"),
                    Description = WebConstants.Grozilcho,
                    Gender = Gender.Male,
                    OwnerId = volunteer.Id,
                    Owner = volunteer,
                    Location = "Sofia"
                },
                new AdoptionCat
                {
                    Name = "Brulee",
                    Age = 1,
                    Image = web.DownloadData("https://scontent-sof1-1.xx.fbcdn.net/v/t31.0-8/18623314_782345918599952_1417075640115888942_o.jpg?oh=83de7ab69469124bb71b2549192f082c&oe=5B3D8C66"),
                    Description = WebConstants.Brulee,
                    Gender = Gender.Female,
                    OwnerId = volunteer.Id,
                    Owner = volunteer,
                    Location = "Sofia"
                },
                new AdoptionCat
                {
                    Name = "Muffin",
                    Age = 1,
                    Image = web.DownloadData("https://scontent-sof1-1.xx.fbcdn.net/v/t31.0-8/18699513_782349261932951_5029592136172705930_o.jpg?oh=7954b2d39d7e59345dfc0f9377491e32&oe=5B325DD7"),
                    Description = WebConstants.Muffin,
                    Gender = Gender.Female,
                    OwnerId = volunteer.Id,
                    Owner = volunteer,
                    Location = "Sofia"
                },
                new AdoptionCat
                {
                    Name = "Cream",
                    Age = 1,
                    Image = web.DownloadData("https://scontent-sof1-1.xx.fbcdn.net/v/t31.0-8/18671706_782343438600200_875940841878914415_o.jpg?oh=fda3578bb823dd6fbd125dd302002ddf&oe=5B0036CA"),
                    Description = WebConstants.Cream,
                    Gender = Gender.Male,
                    OwnerId = volunteer.Id,
                    Owner = volunteer,
                    Location = "Sofia"
                },
                new AdoptionCat
                {
                    Name = "Luke",
                    Age = 1,
                    Image = web.DownloadData("https://scontent-sof1-1.xx.fbcdn.net/v/t31.0-8/14047335_631230213711524_9204681538485371297_o.jpg?oh=4334e46d3c161bb60ad48eccb8c474f9&oe=5B02D9D9"),
                    Description = WebConstants.Luke,
                    Gender = Gender.Male,
                    OwnerId = volunteer.Id,
                    Owner = volunteer,
                    Location = "Sofia"
                },
                new AdoptionCat
                {
                    Name = "Kivi",
                    Age = 1,
                    Image = web.DownloadData("https://scontent-sof1-1.xx.fbcdn.net/v/t31.0-8/16178968_715668668601011_4325405543964809220_o.jpg?oh=5d6fc68047788249724fb35b38109861&oe=5B385B86"),
                    Description = WebConstants.Kivi,
                    Gender = Gender.Male,
                    OwnerId = volunteer.Id,
                    Owner = volunteer,
                    Location = "Sofia"
                },
                new AdoptionCat
                {
                    Name = "Chochi",
                    Age = 1,
                    Image = web.DownloadData("https://scontent-sof1-1.xx.fbcdn.net/v/t31.0-8/12232882_521414694693077_2145851208540449264_o.jpg?oh=da83081b02a7448bb3c24b26842adc95&oe=5B4071D3"),
                    Description = WebConstants.Chochi,
                    Gender = Gender.Female,
                    OwnerId = volunteer.Id,
                    Owner = volunteer,
                    Location = "Sofia"
                },
                new AdoptionCat
                {
                    Name = "Shushi",
                    Age = 1,
                    Image = web.DownloadData("https://scontent-sof1-1.xx.fbcdn.net/v/t31.0-8/12113545_514916665342880_372997120801242710_o.jpg?oh=afceffcd403795cb8cc06ca5b227c16d&oe=5B41102C"),
                    Description = WebConstants.Sushi,
                    Gender = Gender.Female,
                    OwnerId = volunteer.Id,
                    Owner = volunteer,
                    Location = "Sofia"
                },
                new AdoptionCat
                {
                    Name = "Timi",
                    Age = 2,
                    Image = web.DownloadData("https://scontent-sof1-1.xx.fbcdn.net/v/t31.0-8/11893903_516312615203285_1022966195358161655_o.jpg?oh=1126caa25ed53c9dabf827dc123e7232&oe=5B4876CD"),
                    Description = WebConstants.Timi,
                    Gender = Gender.Male,
                    OwnerId = volunteer.Id,
                    Owner = volunteer,
                    Location = "Sofia"
                },
                new AdoptionCat
                {
                    Name = "Ashi",
                    Age = 2,
                    Image = web.DownloadData("https://scontent-sof1-1.xx.fbcdn.net/v/t31.0-8/11722506_483773378457209_974622022689315923_o.jpg?oh=40af45e8f26a85b9d67787024c8569ea&oe=5B39A7A8"),
                    Description = WebConstants.Ashi,
                    Gender = Gender.Female,
                    OwnerId = volunteer.Id,
                    Owner = volunteer,
                    Location = "Sofia"
                },
                new AdoptionCat
                {
                    Name = "Wolly",
                    Age = 1,
                    Image = web.DownloadData("https://scontent-sof1-1.xx.fbcdn.net/v/t31.0-8/19488895_803840366450507_6072711793225561971_o.jpg?oh=f4d175a1d07d3b18d6b627b2c0f24bf0&oe=5B00AF9E"),
                    Description = WebConstants.Wolly,
                    Gender = Gender.Male,
                    OwnerId = volunteer.Id,
                    Owner = volunteer,
                    Location = "Sofia"
                },
                new AdoptionCat
                {
                    Name = "Teo",
                    Age = 1,
                    Image = web.DownloadData("https://scontent-sof1-1.xx.fbcdn.net/v/t31.0-8/19621129_806957312805479_7749141324344621316_o.jpg?oh=1832e08caf5c71819a572bf572ad8bbc&oe=5B41EE80"),
                    Description = WebConstants.Teo,
                    Gender = Gender.Male,
                    OwnerId = volunteer.Id,
                    Owner = volunteer,
                    Location = "Sofia"
                },
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