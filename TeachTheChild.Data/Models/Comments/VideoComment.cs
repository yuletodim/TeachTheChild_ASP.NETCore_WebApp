namespace TeachTheChild.Data.Models.Comments
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using TeachTheChild.Data.Models.Answers;
    using TeachTheChild.Data.Models.Materials;

    public class VideoComment : Comment
    {
        [Required]
        public int VideoId { get; set; }

        public Video Video { get; set; }

        public IEnumerable<VideoCommentAnswer> Answers { get; set; } = new List<VideoCommentAnswer>();
    }
}
