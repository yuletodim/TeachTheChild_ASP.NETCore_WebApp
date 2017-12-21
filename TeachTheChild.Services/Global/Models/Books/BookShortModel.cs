namespace TeachTheChild.Services.Global.Models.Books
{
    using TeachTheChild.Common.Mappings;
    using TeachTheChild.Data.Models.Books;

    public class BookShortModel : IMapFrom<Book>
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Author { get; set; }

        public string Publisher { get; set; }

        public string PictureUrl { get; set; }
    }
}
