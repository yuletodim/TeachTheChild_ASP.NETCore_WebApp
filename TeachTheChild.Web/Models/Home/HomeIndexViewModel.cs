namespace TeachTheChild.Web.Models.Home
{
    using System.Collections.Generic;
    using TeachTheChild.Services.Global.Models.Articles;
    using TeachTheChild.Services.Global.Models.Books;
    using TeachTheChild.Services.Global.Models.Downloads;
    using TeachTheChild.Services.Global.Models.Videos;

    public class HomeIndexViewModel
    {
        public IEnumerable<ArticleShortModel> Articles { get; set; }

        public IEnumerable<BookShortModel> Books { get; set; }

        public IEnumerable<DownloadShortModel> Downloads { get; set; }

        public VideoDetailsModel Video { get; set; }
    }
}
