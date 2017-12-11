namespace TeachTheChild.Data.Models
{
    using Microsoft.AspNetCore.Identity;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using TeachTheChild.Data.Models.Answers;
    using TeachTheChild.Data.Models.Comments;
    using TeachTheChild.Data.Models.Common;
    using TeachTheChild.Data.Models.Likes;
    using TeachTheChild.Data.Models.Materials;

    public class User : IdentityUser, IAuditInfo
    {
        [Required]
        [MinLength(DataConstants.UserNameMinLength)]
        [MaxLength(DataConstants.UserNameMaxLength)]
        public string Name { get; set; }

        [Required]
        public int CountryId { get; set; }

        public Country Country { get; set; }

        public int LanguageId { get; set; }

        [Required]
        public Language Language { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public List<Article> Articles { get; set; } = new List<Article>();

        public List<ArticleComment> ArticleComments { get; set; } = new List<ArticleComment>();

        public List<ArticleCommentAnswer> ArticleCommentAnswers { get; set; } = new List<ArticleCommentAnswer>();

        public List<ArticleLike> ArticleLikes { get; set; } = new List<ArticleLike>();

        public List<Book> Books { get; set; } = new List<Book>();

        public List<BookComment> BookComments { get; set; } = new List<BookComment>();

        public List<BookCommentAnswer> BookCommentAnswers { get; set; } = new List<BookCommentAnswer>();

        public List<BookLike> BookLikes { get; set; } = new List<BookLike>();

        public List<Video> Videos { get; set; } = new List<Video>();

        public List<VideoComment> VideoComments { get; set; } = new List<VideoComment>();

        public List<VideoCommentAnswer> VideoCommentAnswers { get; set; } = new List<VideoCommentAnswer>();

        public List<VideoLike> VideoLikes { get; set; } = new List<VideoLike>();
    }
}
