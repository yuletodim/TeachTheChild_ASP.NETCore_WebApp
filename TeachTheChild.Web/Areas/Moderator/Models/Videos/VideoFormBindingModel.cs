namespace TeachTheChild.Web.Areas.Moderator.Models.Videos
{
    using Microsoft.AspNetCore.Http;
    using System.ComponentModel.DataAnnotations;
    using TeachTheChild.Common.Mappings;
    using TeachTheChild.Data;
    using TeachTheChild.Services.Moderator.Models.Videos;

    public class VideoFormBindingModel : IMapFrom<VideoFormModel>, IMapTo<VideoFormModel>
    {
        public int Id { get; set; }

        public string UserId { get; set; }

        public int LanguageId { get; set; }

        [Required]
        [MinLength(DataConstants.VideoTitleMinLength)]
        [MaxLength(DataConstants.VideoTitleMaxLength)]
        public string Title { get; set; }

        public string Url { get; set; }

        [MaxLength(DataConstants.VideoDescritpionMaxLength)]
        public string Description { get; set; }

        [Required]
        [MinLength(DataConstants.VideoSourceMinLength)]
        [MaxLength(DataConstants.VideoSourceMaxLength)]
        public string Source { get; set; }

        [Required]
        public IFormFile File { get; set; }
    }
}
