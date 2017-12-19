namespace TeachTheChild.Data.Models
{
    using Microsoft.AspNetCore.Identity;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using TeachTheChild.Data.Models.Articles;
    using TeachTheChild.Data.Models.Books;
    using TeachTheChild.Data.Models.Common;
    using TeachTheChild.Data.Models.DownloadMaterials;
    using TeachTheChild.Data.Models.Videos;

    public class User : IdentityUser, IAuditInfo
    {
        [Required]
        [MinLength(DataConstants.UserNameMinLength)]
        [MaxLength(DataConstants.UserNameMaxLength)]
        public string Name { get; set; }

        public int? CountryId { get; set; }

        public Country Country { get; set; }

        [Required]
        public int LanguageId { get; set; }

        public Language Language { get; set; }

        [Required]
        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public List<Article> Articles { get; set; } = new List<Article>();

        public List<ArticleLike> ArticleLikes { get; set; } = new List<ArticleLike>();

        public List<ArticleComment> ArticleComments { get; set; } = new List<ArticleComment>();

        public List<ArticleCommentLike> ArticleCommentLikes { get; set; } = new List<ArticleCommentLike>();

        public List<Book> Books { get; set; } = new List<Book>();

        public List<BookLike> BookLikes { get; set; } = new List<BookLike>();

        public List<BookComment> BookComments { get; set; } = new List<BookComment>();

        public List<BookCommentLike> BookCommentLikes { get; set; } = new List<BookCommentLike>();

        public List<Video> Videos { get; set; } = new List<Video>();

        public List<VideoLike> VideoLikes { get; set; } = new List<VideoLike>();

        public List<VideoComment> VideoComments { get; set; } = new List<VideoComment>();

        public List<VideoCommentLike> VideoCommentLikes { get; set; } = new List<VideoCommentLike>();

        public List<DownloadMaterial> DownloadMaterials { get; set; } = new List<DownloadMaterial>();
    }
}
