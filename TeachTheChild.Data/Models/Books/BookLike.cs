namespace TeachTheChild.Data.Models.Books
{
    using TeachTheChild.Data.Models.Common;

    public class BookLike : BaseLikeModel
    {
        public int BookId { get; set; }

        public Book Book { get; set; }
    }
}
