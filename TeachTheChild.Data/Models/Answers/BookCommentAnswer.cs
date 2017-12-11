namespace TeachTheChild.Data.Models.Answers
{
    using System.ComponentModel.DataAnnotations;
    using TeachTheChild.Data.Models.Comments;

    public class BookCommentAnswer : CommentAnswer
    {
        [Required]
        public int BookCommentId { get; set; }

        public BookComment BookComment { get; set; }
    }
}
