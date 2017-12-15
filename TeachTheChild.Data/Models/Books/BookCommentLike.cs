namespace TeachTheChild.Data.Models.Books
{
    using Common;

    public class BookCommentLike : BaseLikeModel
    {
        public int BookCommentId { get; set; }

        public BookComment Comment { get; set; }
    }
}
