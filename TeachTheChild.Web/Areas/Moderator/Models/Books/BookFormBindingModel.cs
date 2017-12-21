namespace TeachTheChild.Web.Areas.Moderator.Models.Books
{
    using Microsoft.AspNetCore.Http;
    using System.ComponentModel.DataAnnotations;
    using TeachTheChild.Common.Mappings;
    using TeachTheChild.Data;
    using TeachTheChild.Services.Moderator.Models.Books;

    public class BookFormBindingModel : IMapFrom<BookFormModel>, IMapTo<BookFormModel>
    {
        public int Id { get; set; }

        public string UserId { get; set; }

        public int LanguageId { get; set; }

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

        public IFormFile File { get; set; }
    }
}
