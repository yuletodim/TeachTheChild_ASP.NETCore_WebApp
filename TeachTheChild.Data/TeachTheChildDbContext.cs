namespace TeachTheChild.Data
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    using TeachTheChild.Data.Models;
    using TeachTheChild.Data.Models.Answers;
    using TeachTheChild.Data.Models.Comments;
    using TeachTheChild.Data.Models.Common;
    using TeachTheChild.Data.Models.Likes;
    using TeachTheChild.Data.Models.Materials;

    public class TeachTheChildDbContext : IdentityDbContext<User>
    {
        public TeachTheChildDbContext(DbContextOptions<TeachTheChildDbContext> options)
            : base(options)
        {
        }

        public DbSet<Language> Languages { get; set; }

        public DbSet<Country> Countries { get; set; }

        public DbSet<Article> Articles { get; set; }

        public DbSet<ArticleComment> ArticleComments { get; set; }

        public DbSet<ArticleCommentAnswer> ArticleCommentAnswers { get; set; }

        public DbSet<ArticleLike> ArticleLikes { get; set; }

        public DbSet<Book> Books { get; set; }

        public DbSet<BookComment> BookComments { get; set; }

        public DbSet<BookCommentAnswer> BookCommentAnswers { get; set; }

        public DbSet<BookLike> BookLikes { get; set; }

        public DbSet<Video> Videos { get; set; }

        public DbSet<VideoComment> VideoComments { get; set; }

        public DbSet<VideoCommentAnswer> VideoCommentAnswers { get; set; }

        public DbSet<VideoLike> VideoLikes { get; set; }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            this.ApplyAuditInfoRules();
            return await base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>()
                .HasOne(u => u.Country)
                .WithMany(c => c.Users)
                .HasForeignKey(u => u.CountryId);

            builder.Entity<User>()
                .HasOne(u => u.Language)
                .WithMany(l => l.Users)
                .HasForeignKey(u => u.LanguageId);

            builder.Entity<User>()
                .HasMany(u => u.Articles)
                .WithOne(r => r.User)
                .HasForeignKey(r => r.UserId);

            builder.Entity<ArticleComment>()
                .HasOne(ac => ac.User)
                .WithMany(u => u.ArticleComments)
                .HasForeignKey(ac => ac.UserId);

            builder.Entity<ArticleComment>()
                .HasOne(ac => ac.Article)
                .WithMany(a => a.Comments)
                .HasForeignKey(ac => ac.ArticleId);

            builder.Entity<ArticleCommentAnswer>()
                .HasOne(aca => aca.User)
                .WithMany(u => u.ArticleCommentAnswers)
                .HasForeignKey(aca => aca.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<ArticleCommentAnswer>()
                .HasOne(aca => aca.ArticleComment)
                .WithMany(ac => ac.Answers)
                .HasForeignKey(aca => aca.ArticleCommentId);

            builder.Entity<User>()
                .HasMany(u => u.Books)
                .WithOne(b => b.User)
                .HasForeignKey(b => b.UserId);

            builder.Entity<BookComment>()
                .HasOne(bc => bc.User)
                .WithMany(u => u.BookComments)
                .HasForeignKey(bc => bc.UserId);

            builder.Entity<BookComment>()
                .HasOne(bc => bc.Book)
                .WithMany(b => b.Comments)
                .HasForeignKey(bc => bc.BookId);

            builder.Entity<BookCommentAnswer>()
                .HasOne(bca => bca.User)
                .WithMany(u => u.BookCommentAnswers)
                .HasForeignKey(bca => bca.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<BookCommentAnswer>()
                .HasOne(bca => bca.BookComment)
                .WithMany(bc => bc.Answers)
                .HasForeignKey(bca => bca.BookCommentId);

            builder.Entity<User>()
                .HasMany(u => u.Videos)
                .WithOne(v => v.User)
                .HasForeignKey(v => v.UserId);

            builder.Entity<VideoComment>()
                .HasOne(vc => vc.User)
                .WithMany(u => u.VideoComments)
                .HasForeignKey(vc => vc.UserId);

            builder.Entity<VideoComment>()
                .HasOne(vc => vc.Video)
                .WithMany(v => v.Comments)
                .HasForeignKey(vc => vc.VideoId);

            builder.Entity<VideoCommentAnswer>()
                .HasOne(vca => vca.User)
                .WithMany(u => u.VideoCommentAnswers)
                .HasForeignKey(vca => vca.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<VideoCommentAnswer>()
                .HasOne(vca => vca.VideoComment)
                .WithMany(vc => vc.Answers)
                .HasForeignKey(vca => vca.VideoCommentId);

            builder.Entity<ArticleLike>()
                .HasKey(al => new { al.UserId, al.ArticleId });

            builder.Entity<ArticleLike>()
                .HasOne(al => al.Article)
                .WithMany(a => a.Likes)
                .HasForeignKey(al => al.ArticleId);

            builder.Entity<ArticleLike>()
                .HasOne(al => al.User)
                .WithMany(u => u.ArticleLikes)
                .HasForeignKey(al => al.UserId);

            builder.Entity<BookLike>()
                .HasKey(bl => new { bl.UserId, bl.BookId });

            builder.Entity<BookLike>()
                .HasOne(bl => bl.Book)
                .WithMany(b => b.Likes)
                .HasForeignKey(bl => bl.BookId);

            builder.Entity<BookLike>()
                .HasOne(bl => bl.User)
                .WithMany(u => u.BookLikes)
                .HasForeignKey(bl => bl.UserId);

            builder.Entity<VideoLike>()
                .HasKey(vl => new { vl.UserId, vl.VideoId });

            builder.Entity<VideoLike>()
                .HasOne(vl => vl.Video)
                .WithMany(v => v.Likes)
                .HasForeignKey(vl => vl.VideoId);

            builder.Entity<VideoLike>()
                .HasOne(vl => vl.User)
                .WithMany(u => u.VideoLikes)
                .HasForeignKey(vl => vl.UserId);

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
