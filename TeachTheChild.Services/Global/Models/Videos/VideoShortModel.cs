namespace TeachTheChild.Services.Global.Models.Videos
{
    using System;
    using TeachTheChild.Common.Mappings;
    using TeachTheChild.Data.Models.Videos;

    public class VideoShortModel : IMapFrom<Video>
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
