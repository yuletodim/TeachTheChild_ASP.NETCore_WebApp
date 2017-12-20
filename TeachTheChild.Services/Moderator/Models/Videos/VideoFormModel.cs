namespace TeachTheChild.Services.Moderator.Models.Videos
{
    using TeachTheChild.Common.Mappings;
    using TeachTheChild.Data.Models.Videos;

    public class VideoFormModel : IMapFrom<Video>, IMapTo<Video>
    {
        public int Id { get; set; }

        public string UserId { get; set; }

        public int LanguageId { get; set; }

        public string Title { get; set; }

        public string Url { get; set; }

        public string Description { get; set; }

        public string Source { get; set; }
    }
}
