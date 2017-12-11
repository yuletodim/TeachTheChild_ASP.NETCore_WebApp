namespace TeachTheChild.Data.Models.Likes
{
    using TeachTheChild.Data.Models.Materials;

    public class BookLike : BaseLikeModel
    {
        public int BookId { get; set; }

        public Book Book { get; set; }
    }
}
