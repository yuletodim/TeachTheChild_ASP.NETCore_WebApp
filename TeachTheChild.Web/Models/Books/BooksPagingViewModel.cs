namespace TeachTheChild.Web.Models.Books
{
    using System.Collections.Generic;
    using TeachTheChild.Services.Global.Models.Books;

    public class BooksPagingViewModel
    {
        public IEnumerable<BookShortModel> Books { get; set; }

        public int CurrentPage { get; set; }

        public int PreviousePage => this.CurrentPage == 1 ? 1 : this.CurrentPage - 1;

        public int PagesCount { get; set; }

        public int NextPage => this.CurrentPage == this.PagesCount ? this.PagesCount : this.CurrentPage + 1;
    }
}
