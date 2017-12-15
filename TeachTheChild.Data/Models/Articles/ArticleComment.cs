namespace TeachTheChild.Data.Models.Articles
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using TeachTheChild.Data.Models.Common;

    public class ArticleComment : Comment
    {
        [Required]
        public int ArticleId { get; set; }

        public Article Article { get; set; }

        public int? BaseCommentId { get; set; }

        public ArticleComment BaseComment { get; set; }

        public List<ArticleComment> Answers { get; set; } = new List<ArticleComment>();

        public List<ArticleCommentLike> Likes { get; set; } = new List<ArticleCommentLike>();
    }
}
