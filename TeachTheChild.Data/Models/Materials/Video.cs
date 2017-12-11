namespace TeachTheChild.Data.Models.Materials
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using TeachTheChild.Data.Models.Comments;
    using TeachTheChild.Data.Models.Likes;

    public class Video : Material
    {
        [Required]
        [MinLength(DataConstants.VideoTitleMinLength)]
        [MaxLength(DataConstants.VideoTitleMaxLength)]
        public string Title { get; set; }

        [Required]
        [Url]
        public string Url { get; set; }

        [MaxLength(DataConstants.VideoDescritpionMaxLength)]
        public string Description { get; set; }

        [Required]
        [MinLength(DataConstants.VideoSourceMinLength)]
        [MaxLength(DataConstants.VideoSourceMaxLength)]
        public string Source { get; set; }

        public List<VideoComment> Comments { get; set; } = new List<VideoComment>();

        public List<VideoLike> Likes { get; set; } = new List<VideoLike>();
    }
}
