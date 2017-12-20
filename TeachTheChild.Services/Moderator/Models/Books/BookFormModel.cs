namespace TeachTheChild.Services.Moderator.Models.Books
{
    using TeachTheChild.Common.Mappings;
    using TeachTheChild.Data.Models.Books;

    public class BookFormModel : IMapFrom<Book>, IMapTo<Book>
    {
        public int Id { get; set; }

        public string UserId { get; set; }

        public int LanguageId { get; set; }

        public string Title { get; set; }

        public string Author { get; set; }

        public string Publisher { get; set; }

        public string Descritpion { get; set; }

        public string PictureUrl { get; set; }
    }
}
