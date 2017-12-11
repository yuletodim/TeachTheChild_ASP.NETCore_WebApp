namespace TeachTheChild.Data.Models.Comments
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using TeachTheChild.Data.Models.Answers;
    using TeachTheChild.Data.Models.Materials;

    public class BookComment : Comment
    {
        [Required]
        public int BookId { get; set; }

        public Book Book { get; set; }

        public List<BookCommentAnswer> Answers { get; set; } = new List<BookCommentAnswer>();
    }
}
