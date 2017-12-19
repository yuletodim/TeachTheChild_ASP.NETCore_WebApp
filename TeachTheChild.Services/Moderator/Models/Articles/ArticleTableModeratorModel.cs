namespace TeachTheChild.Services.Moderator.Models.Articles
{
    using AutoMapper;
    using System;
    using System.Linq;
    using TeachTheChild.Common.Mappings;
    using TeachTheChild.Data.Models.Articles;

    public class ArticleTableModeratorModel : IMapFrom<Article>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string UserId { get; set; }

        public string Author { get; set; }

        public DateTime CreatedOn { get; set; }

        public int CommentsCount { get; set; }

        public int LikesCount { get; set; }

        public int DislikesCount { get; set; }

        public void ApplyCustomMappings(Profile profile)
        {
            profile.CreateMap<Article, ArticleTableModeratorModel>()
                .ForMember(a => a.Author, opt => opt.MapFrom(a => a.User.Name))
                .ForMember(a => a.CommentsCount, opt => opt.MapFrom(a => a.Comments.Count))
                .ForMember(a => a.LikesCount, opt => opt.MapFrom(a => a.Likes.Where(l => l.IsLike == true).Count()))
                .ForMember(a => a.DislikesCount, opt => opt.MapFrom(a => a.Likes.Where(l => l.IsLike == false).Count()));
        }
    }
}
