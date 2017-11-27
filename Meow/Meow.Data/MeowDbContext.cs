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

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}