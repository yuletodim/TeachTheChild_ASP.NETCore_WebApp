namespace TeachTheChild.Data.Models.Videos
{
    using TeachTheChild.Data.Models.Common;

    public class VideoLike : BaseLikeModel
    {
        public int VideoId { get; set; }

        public Video Video { get; set; }
    }
}
