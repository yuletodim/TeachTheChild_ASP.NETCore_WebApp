namespace TeachTheChild.Web.Models.Videos
{

    using System.Collections.Generic;
    using TeachTheChild.Services.Global.Models.Videos;

    public class VideosPagingViewModel
    {
        public VideoDetailsModel Video { get; set; }

        public IEnumerable<VideoShortModel> Videos { get; set; }

        public int CurrentPage { get; set; }

        public int PreviousePage => this.CurrentPage == 1 ? 1 : this.CurrentPage - 1;

        public int PagesCount { get; set; }

        public int NextPage => this.CurrentPage == this.PagesCount ? this.PagesCount : this.CurrentPage + 1;
    }
}
