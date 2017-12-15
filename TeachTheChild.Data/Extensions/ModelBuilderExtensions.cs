namespace TeachTheChild.Data.Extensions
{
    using Microsoft.EntityFrameworkCore;
    using TeachTheChild.Data.Models;
    using TeachTheChild.Data.Models.Articles;
    using TeachTheChild.Data.Models.Books;
    using TeachTheChild.Data.Models.DownloadMaterials;
    using TeachTheChild.Data.Models.Videos;

    public static class ModelBuilderExtensions
    {
        public static void AddUserRelations(this ModelBuilder builder)
        {
            builder.Entity<User>()
               .HasOne(u => u.Country)
               .WithMany(c => c.Users)
               .HasForeignKey(u => u.CountryId);

            builder.Entity<User>()
                .HasOne(u => u.Language)
                .WithMany(l => l.Users)
                .HasForeignKey(u => u.LanguageId);
        }

        public static void AddArticleRelations(this ModelBuilder builder)
        {
            builder.Entity<Article>()
                .HasOne(a => a.User)
                .WithMany(u => u.Articles)
                .HasForeignKey(a => a.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Article>()
                .HasOne(a => a.Language)
                .WithMany(l => l.Articles)
                .HasForeignKey(a => a.LanguageId);

            builder.Entity<ArticleLike>()
               .HasKey(al => new { al.UserId, al.ArticleId });

            builder.Entity<ArticleLike>()
                .HasOne(al => al.Article)
                .WithMany(a => a.Likes)
                .HasForeignKey(al => al.ArticleId);

            builder.Entity<ArticleLike>()
                .HasOne(al => al.User)
                .WithMany(u => u.ArticleLikes)
                .HasForeignKey(al => al.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<ArticleComment>()
                .HasOne(ac => ac.User)
                .WithMany(u => u.ArticleComments)
                .HasForeignKey(ac => ac.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<ArticleComment>()
                .HasOne(ac => ac.Article)
                .WithMany(a => a.Comments)
                .HasForeignKey(ac => ac.ArticleId);

            builder.Entity<ArticleComment>()
                 .HasOne(ac => ac.BaseComment)
                 .WithMany(bc => bc.Answers)
                 .HasForeignKey(ac => ac.BaseCommentId);

            builder.Entity<ArticleCommentLike>()
                .HasKey(acl => new { acl.UserId, acl.ArticleCommentId });

            builder.Entity<ArticleCommentLike>()
                .HasOne(acl => acl.User)
                .WithMany(u => u.ArticleCommentLikes)
                .HasForeignKey(acl => acl.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<ArticleCommentLike>()
                .HasOne(acl => acl.Comment)
                .WithMany(c => c.Likes)
                .HasForeignKey(acl => acl.ArticleCommentId);
        }

        public static void AddBookRelations(this ModelBuilder builder)
        {
            builder.Entity<Book>()
                .HasOne(a => a.User)
                .WithMany(u => u.Books)
                .HasForeignKey(a => a.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Book>()
                .HasOne(a => a.Language)
                .WithMany(l => l.Books)
                .HasForeignKey(a => a.LanguageId);

            builder.Entity<BookLike>()
                .HasKey(bl => new { bl.UserId, bl.BookId });

            builder.Entity<BookLike>()
                .HasOne(bl => bl.Book)
                .WithMany(b => b.Likes)
                .HasForeignKey(bl => bl.BookId);

            builder.Entity<BookLike>()
                .HasOne(bl => bl.User)
                .WithMany(u => u.BookLikes)
                .HasForeignKey(bl => bl.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<BookComment>()
                .HasOne(bc => bc.User)
                .WithMany(u => u.BookComments)
                .HasForeignKey(bc => bc.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<BookComment>()
                .HasOne(bc => bc.Book)
                .WithMany(b => b.Comments)
                .HasForeignKey(bc => bc.BookId);

            builder.Entity<BookComment>()
                 .HasOne(ac => ac.BaseComment)
                 .WithMany(bc => bc.Answers)
                 .HasForeignKey(ac => ac.BaseCommentId);

            builder.Entity<BookCommentLike>()
                .HasKey(acl => new { acl.UserId, acl.BookCommentId });

            builder.Entity<BookCommentLike>()
                .HasOne(acl => acl.User)
                .WithMany(u => u.BookCommentLikes)
                .HasForeignKey(acl => acl.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<BookCommentLike>()
                .HasOne(acl => acl.Comment)
                .WithMany(c => c.Likes)
                .HasForeignKey(acl => acl.BookCommentId);
        }

        public static void AddVideoRelations(this ModelBuilder builder)
        {
            builder.Entity<Video>()
                .HasOne(v => v.User)
                .WithMany(u => u.Videos)
                .HasForeignKey(v => v.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Video>()
                .HasOne(v => v.Language)
                .WithMany(l => l.Videos)
                .HasForeignKey(v => v.LanguageId);

            builder.Entity<VideoLike>()
                .HasKey(vl => new { vl.UserId, vl.VideoId });

            builder.Entity<VideoLike>()
                .HasOne(vl => vl.Video)
                .WithMany(v => v.Likes)
                .HasForeignKey(vl => vl.VideoId);

            builder.Entity<VideoLike>()
                .HasOne(vl => vl.User)
                .WithMany(u => u.VideoLikes)
                .HasForeignKey(vl => vl.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<VideoComment>()
                .HasOne(vc => vc.User)
                .WithMany(u => u.VideoComments)
                .HasForeignKey(vc => vc.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<VideoComment>()
                .HasOne(vc => vc.Video)
                .WithMany(v => v.Comments)
                .HasForeignKey(vc => vc.VideoId);

            builder.Entity<VideoComment>()
                 .HasOne(ac => ac.BaseComment)
                 .WithMany(bc => bc.Answers)
                 .HasForeignKey(ac => ac.BaseCommentId);

            builder.Entity<VideoCommentLike>()
                .HasKey(vcl => new { vcl.UserId, vcl.VideoCommentId });

            builder.Entity<VideoCommentLike>()
                .HasOne(vcl => vcl.User)
                .WithMany(u => u.VideoCommentLikes)
                .HasForeignKey(vcl => vcl.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<VideoCommentLike>()
                .HasOne(vcl => vcl.Comment)
                .WithMany(c => c.Likes)
                .HasForeignKey(vcl => vcl.VideoCommentId);
        }

        public static void AddDownloadMaterialRelations(this ModelBuilder builder)
        {
            builder.Entity<DownloadMaterial>()
                .HasOne(dm => dm.User)
                .WithMany(u => u.DownloadMaterials)
                .HasForeignKey(dm => dm.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<DownloadMaterial>()
                .HasOne(dm => dm.Language)
                .WithMany(l => l.DownloadMaterials)
                .HasForeignKey(dm => dm.LanguageId);
        }
    }
}
