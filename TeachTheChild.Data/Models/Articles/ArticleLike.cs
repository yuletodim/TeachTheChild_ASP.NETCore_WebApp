namespace TeachTheChild.Data.Models.Articles
{
    using TeachTheChild.Data.Models.Common;

    public class ArticleLike : BaseLikeModel
    {
        public int ArticleId { get; set; }

        public Article Article { get; set; }
    }
}
