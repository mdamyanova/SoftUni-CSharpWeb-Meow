namespace Meow.Data
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using Models;

    public class MeowDbContext : IdentityDbContext<User>
    {
        public MeowDbContext(DbContextOptions<MeowDbContext> options)
            : base(options)
        {
        }

        public DbSet<AdoptionCat> AdoptionCats { get; set; }

        public DbSet<HomeCat> HomeCats { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .Entity<AdoptionCatUser>()
                .HasKey(au => new {au.AdoptionCatId, au.AdopterId});

            builder
                .Entity<AdoptionCatUser>()
                .HasOne(au => au.AdoptionCat)
                .WithMany(s => s.Adopters)
                .HasForeignKey(au => au.AdoptionCatId);

            builder
                .Entity<AdoptionCatUser>()
                .HasOne(au => au.Adopter)
                .WithMany(c => c.CatsForAdoption)
                .HasForeignKey(au => au.AdopterId);

            builder
                .Entity<AdoptionCat>()
                .HasOne(c => c.Owner)
                .WithMany(o => o.AdoptedCats)
                .HasForeignKey(c => c.OwnerId);

            builder
             .Entity<HomeCat>()
             .HasOne(c => c.Owner)
             .WithMany(o => o.HomeCats)
             .HasForeignKey(c => c.OwnerId);

            base.OnModelCreating(builder);
        }
    }
}