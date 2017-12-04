namespace Meow.Data
{
    using Meow.Data.Models;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

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