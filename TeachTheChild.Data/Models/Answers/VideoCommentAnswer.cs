namespace TeachTheChild.Data.Models.Answers
{
    using System.ComponentModel.DataAnnotations;
    using TeachTheChild.Data.Models.Comments;

    public class VideoCommentAnswer : CommentAnswer
    {
        [Required]
        public int VideoCommentId { get; set; }

        public VideoComment VideoComment { get; set; }
    }
}
