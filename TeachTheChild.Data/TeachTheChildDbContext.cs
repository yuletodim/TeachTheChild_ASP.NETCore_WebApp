namespace TeachTheChild.Data
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using TeachTheChild.Data.Models;

    public class TeachTheChildDbContext : IdentityDbContext<User>
    {
        public TeachTheChildDbContext(DbContextOptions<TeachTheChildDbContext> options)
            : base(options)
        {
        }

        public DbSet<Country> Countries { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .Entity<User>()
                .HasOne(u => u.Country)
                .WithMany(c => c.Users)
                .HasForeignKey(u => u.CountryId);

            base.OnModelCreating(builder);
        }
    }
}
