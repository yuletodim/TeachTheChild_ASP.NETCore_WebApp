namespace TeachTheChild.Data.Models.Videos
{
    using TeachTheChild.Data.Models.Common;

    public class VideoCommentLike : BaseLikeModel
    {
        public int VideoCommentId { get; set; }

        public VideoComment Comment { get; set; } 
    }
}
