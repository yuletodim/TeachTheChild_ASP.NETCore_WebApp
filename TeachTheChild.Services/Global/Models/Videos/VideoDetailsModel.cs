namespace TeachTheChild.Services.Global.Models.Videos
{
    using AutoMapper;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using TeachTheChild.Common.Mappings;
    using TeachTheChild.Data.Models.Videos;

    public class VideoDetailsModel : IMapFrom<Video>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public DateTime CreatedOn { get; set; }

        public string UserId { get; set; }

        public string User { get; set; }

        public int LanguageId { get; set; }

        public string Title { get; set; }

        public string Url { get; set; }

        public string Description { get; set; }

        public List<VideoCommentModel> Comments { get; set; } = new List<VideoCommentModel>();

        public int Likes { get; set; }

        public int Dislikes { get; set; }

        public void ApplyCustomMappings(Profile profile)
        {
            profile.CreateMap<Video, VideoDetailsModel>()
                .ForMember(a => a.User, opt => opt.MapFrom(a => a.User.Name))
                .ForMember(a => a.Likes, opt => opt.MapFrom(a => a.Likes.Where(l => l.IsLike == true).Count()))
                .ForMember(a => a.Dislikes, opt => opt.MapFrom(a => a.Likes.Where(l => l.IsLike == false).Count()));
        }
    }
}
