namespace TeachTheChild.Data.Models.Videos
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using TeachTheChild.Data.Models.Common;

    public class VideoComment : Comment
    {
        [Required]
        public int VideoId { get; set; }

        public Video Video { get; set; }

        public int? BaseCommentId { get; set; }

        public VideoComment BaseComment { get; set; }

        public List<VideoComment> Answers { get; set; } = new List<VideoComment>();

        public List<VideoCommentLike> Likes { get; set; } = new List<VideoCommentLike>();
    }
}
