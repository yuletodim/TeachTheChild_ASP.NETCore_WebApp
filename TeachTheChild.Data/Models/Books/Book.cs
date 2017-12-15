namespace TeachTheChild.Data.Models.Books
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using TeachTheChild.Data.Models.Common;

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

        public string Publisher { get; set; }

        [Required]
        [MinLength(DataConstants.BookDescritpionMinLength)]
        [MaxLength(DataConstants.BookDescritpionMaxLength)]
        public string Descritpion { get; set; }

        public string PictureUrl { get; set; }

        public List<BookComment> Comments { get; set; } = new List<BookComment>();

        public List<BookLike> Likes { get; set; } = new List<BookLike>();
    }
}
