namespace TeachTheChild.Data.Models.Answers
{
    using System.ComponentModel.DataAnnotations;
    using TeachTheChild.Data.Models.Comments;

    public class ArticleCommentAnswer : CommentAnswer
    {
        [Required]
        public int ArticleCommentId { get; set; }

        public ArticleComment ArticleComment { get; set; }
    }
}
