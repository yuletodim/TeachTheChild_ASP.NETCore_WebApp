namespace TeachTheChild.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using TeachTheChild.Data.Models.Common;

    public class Book : BaseModel
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
    }
}
