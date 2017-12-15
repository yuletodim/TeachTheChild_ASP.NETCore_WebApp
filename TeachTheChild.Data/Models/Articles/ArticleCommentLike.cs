namespace TeachTheChild.Data.Models.Articles
{
    using TeachTheChild.Data.Models.Common;

    public class ArticleCommentLike : BaseLikeModel
    {
        public int ArticleCommentId { get; set; }

        public ArticleComment Comment { get; set; }
    }
}
