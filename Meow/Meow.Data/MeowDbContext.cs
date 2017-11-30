namespace Meow.Web.Data
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

        public DbSet<Cat> Cats { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .Entity<Cat>()
                .HasOne(c => c.Owner)
                .WithMany(o => o.Cats)
                .HasForeignKey(c => c.OwnerId);

            base.OnModelCreating(builder);
        }
    }
}