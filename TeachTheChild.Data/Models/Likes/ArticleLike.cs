namespace TeachTheChild.Data.Models.Likes
{
    using TeachTheChild.Data.Models.Materials;

    public class ArticleLike : BaseLikeModel
    {
        public int ArticleId { get; set; }

        public Article Article { get; set; }
    }
}
