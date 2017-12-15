namespace TeachTheChild.Data.Models.Books
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using TeachTheChild.Data.Models.Common;

    public class BookComment : Comment
    {
        [Required]
        public int BookId { get; set; }

        public Book Book { get; set; }

        public int? BaseCommentId { get; set; }

        public BookComment BaseComment { get; set; }

        public List<BookComment> Answers { get; set; } = new List<BookComment>();

        public List<BookCommentLike> Likes { get; set; } = new List<BookCommentLike>();
    }
}
