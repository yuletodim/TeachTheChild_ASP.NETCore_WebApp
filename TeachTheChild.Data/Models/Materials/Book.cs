namespace TeachTheChild.Data.Models.Materials
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using TeachTheChild.Data.Models.Comments;
    using TeachTheChild.Data.Models.Likes;

    public class Book : Material
    {
        [Required]
        [MinLength(DataConstants.BookTitleMinLength)]
        [MaxLength(DataConstants.BookTitleMaxLength)]
        public string Title { get; set; }

        [Required]
        [MinLength(DataConstants.BookAuthorMinLength)]
        [MaxLength(DataConstants.BookAuthorMaxLength)]
        public string Author { get; set; }

        [Required]
        [MinLength(DataConstants.BookDescritpionMinLength)]
        [MaxLength(DataConstants.BookDescritpionMaxLength)]
        public string Descritpion { get; set; }

        public List<BookComment> Comments { get; set; } = new List<BookComment>();

        public List<BookLike> Likes { get; set; } = new List<BookLike>();
    }
}
