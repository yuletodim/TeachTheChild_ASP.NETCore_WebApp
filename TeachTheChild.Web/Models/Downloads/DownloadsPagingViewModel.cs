namespace TeachTheChild.Web.Models.Downloads
{
    using System.Collections.Generic;
    using TeachTheChild.Services.Global.Models.Downloads;

    public class DownloadsPagingViewModel
    {
        public IEnumerable<DownloadShortModel> Downloads { get; set; }

        public int CurrentPage { get; set; }

        public int PreviousePage => this.CurrentPage == 1 ? 1 : this.CurrentPage - 1;

        public int PagesCount { get; set; }

        public int NextPage => this.CurrentPage == this.PagesCount ? this.PagesCount : this.CurrentPage + 1;

        public string Type { get; set; }
    }
}
