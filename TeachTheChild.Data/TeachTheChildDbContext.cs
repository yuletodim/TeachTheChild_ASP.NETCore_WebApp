namespace TeachTheChild.Data
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    using TeachTheChild.Data.Models;
    using TeachTheChild.Data.Models.Common;
    using TeachTheChild.Data.Models.Books;
    using TeachTheChild.Data.Models.Videos;
    using TeachTheChild.Data.Models.Articles;
    using TeachTheChild.Data.Models.DownloadMaterials;
    using TeachTheChild.Data.Extensions;

    public class TeachTheChildDbContext : IdentityDbContext<User>
    {
        public TeachTheChildDbContext(DbContextOptions<TeachTheChildDbContext> options)
            : base(options)
        {
        }

        public DbSet<Language> Languages { get; set; }

        public DbSet<Country> Countries { get; set; }

        public DbSet<Article> Articles { get; set; }

        public DbSet<ArticleLike> ArticleLikes { get; set; }

        public DbSet<ArticleComment> ArticleComments { get; set; }

        public DbSet<ArticleCommentLike> ArticleCommentLikes { get; set; }

        public DbSet<Book> Books { get; set; }

        public DbSet<BookLike> BookLikes { get; set; }

        public DbSet<BookComment> BookComments { get; set; }

        public DbSet<BookCommentLike> BookCommentLikes { get; set; }

        public DbSet<Video> Videos { get; set; }

        public DbSet<VideoLike> VideoLikes { get; set; }

        public DbSet<VideoComment> VideoComments { get; set; }

        public DbSet<VideoCommentLike> VideoCommentLikes { get; set; }

        public DbSet<DownloadMaterial> DownloadMaterials { get; set; }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            this.ApplyAuditInfoRules();
            return await base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.AddUserRelations();

            builder.AddArticleRelations();

            builder.AddBookRelations();

            builder.AddVideoRelations();

            builder.AddDownloadMaterialRelations();

            base.OnModelCreating(builder);
        }

        private void ApplyAuditInfoRules()
        {
            // Approach via @julielerman: http://bit.ly/123661P
            foreach (var entry in
                this.ChangeTracker.Entries()
                    .Where(
                        e =>
                        e.Entity is IAuditInfo && ((e.State == EntityState.Added) || (e.State == EntityState.Modified))))
            {
                var entity = (IAuditInfo)entry.Entity;
                if (entry.State == EntityState.Added && entity.CreatedOn == default(DateTime))
                {
                    entity.CreatedOn = DateTime.UtcNow;
                }
                else
                {
                    entity.ModifiedOn = DateTime.UtcNow;
                }
            }
        }
    }
}
