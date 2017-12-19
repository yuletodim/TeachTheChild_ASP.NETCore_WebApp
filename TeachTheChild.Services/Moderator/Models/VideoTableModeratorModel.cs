namespace TeachTheChild.Services.Moderator.Models
{
    using AutoMapper;
    using System;
    using System.Linq;
    using TeachTheChild.Common.Mappings;
    using TeachTheChild.Data.Models.Videos;

    public class VideoTableModeratorModel : IMapFrom<Video>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string UserId { get; set; }

        public string User { get; set; }

        public string Title { get; set; }

        public string Source { get; set; }

        public DateTime CreatedOn { get; set; }

        public int CommentsCount { get; set; }

        public int LikesCount { get; set; }

        public int DislikesCount { get; set; }

        public void ApplyCustomMappings(Profile profile)
        {
            profile.CreateMap<Video, VideoTableModeratorModel>()
                .ForMember(b => b.User, opt => opt.MapFrom(b => b.User.Name))
                .ForMember(b => b.CommentsCount, opt => opt.MapFrom(b => b.Comments.Count))
                .ForMember(b => b.LikesCount, opt => opt.MapFrom(b => b.Likes.Where(l => l.IsLike == true).Count()))
                .ForMember(b => b.DislikesCount, opt => opt.MapFrom(b => b.Likes.Where(l => l.IsLike == false).Count()));
        }
    }
}
