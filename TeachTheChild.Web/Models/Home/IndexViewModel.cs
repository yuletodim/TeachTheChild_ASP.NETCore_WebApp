namespace TeachTheChild.Web.Models.Home
{
    using System.Collections.Generic;
    using TeachTheChild.Services.Global.Models.Articles;
    using TeachTheChild.Services.Global.Models.Books;
    using TeachTheChild.Services.Global.Models.Videos;

    public class IndexViewModel
    {
        public IEnumerable<ArticleShortModel> Articles { get; set; }

        public IEnumerable<BookShortModel> Books { get; set; }

        public VideoShortModel Video { get; set; }
    }
}
