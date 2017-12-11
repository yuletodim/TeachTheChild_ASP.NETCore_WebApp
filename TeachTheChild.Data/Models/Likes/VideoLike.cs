namespace TeachTheChild.Data.Models.Likes
{
    using TeachTheChild.Data.Models.Materials;

    public class VideoLike : BaseLikeModel
    {
        public int VideoId { get; set; }

        public Video Video { get; set; }
    }
}
