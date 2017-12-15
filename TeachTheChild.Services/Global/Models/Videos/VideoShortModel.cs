namespace TeachTheChild.Services.Global.Models.Videos
{
    using TeachTheChild.Common.Mappings;
    using TeachTheChild.Data.Models.Videos;

    public class VideoShortModel : IMapFrom<Video>
    {
        public int Id { get; set; }

        public string Url { get; set; }
    }
}
