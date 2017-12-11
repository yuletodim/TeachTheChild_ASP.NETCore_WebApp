namespace TeachTheChild.Data.Models.Comments
{
    using System.ComponentModel.DataAnnotations;
    using TeachTheChild.Data.Models.Common;

    public abstract class Comment : BaseModel
    {
        [Required]
        [MinLength(DataConstants.CommentMinLegth)]
        [MaxLength(DataConstants.CommentMaxLegth)]
        public string Content { get; set; }

        [Required]
        public string UserId { get; set; }

        public User User { get; set; }
    }
}
