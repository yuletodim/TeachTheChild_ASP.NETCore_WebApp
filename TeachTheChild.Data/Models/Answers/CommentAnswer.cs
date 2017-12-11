namespace TeachTheChild.Data.Models.Answers
{
    using System.ComponentModel.DataAnnotations;
    using TeachTheChild.Data.Models.Common;

    public abstract class CommentAnswer : BaseModel
    {
        [Required]
        [MinLength(DataConstants.CommentAnswerMinLength)]
        [MaxLength(DataConstants.CommentAnswerMaxLength)]
        public string Content { get; set; }

        [Required]
        public string UserId { get; set; }

        public User User { get; set; }
    }
}
