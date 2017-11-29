namespace TeachTheChild.Web.Data
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

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
