namespace TeachTheChild.Services.Global.Models.Articles
{
    using System;
    using AutoMapper;
    using TeachTheChild.Common.Mappings;
    using TeachTheChild.Data.Models.Articles;
    using System.Collections.Generic;
    using System.Linq;

    public class ArticleDetailsModel : IMapFrom<Article>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public DateTime CreatedOn { get; set; }

        public string UserId { get; set; }

        public string Author { get; set; }

        public int LanguageId { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public List<ArticleCommentModel> Comments { get; set; } = new List<ArticleCommentModel>();

        public int Likes { get; set; }

        public int Dislikes { get; set; }

        public void ApplyCustomMappings(Profile profile)
        {
            profile.CreateMap<Article, ArticleDetailsModel>()
                .ForMember(a => a.Author, opt => opt.MapFrom(a => a.User.Name))
                .ForMember(a => a.Likes, opt => opt.MapFrom(a => a.Likes.Where(l => l.IsLike == true).Count()))
                .ForMember(a => a.Dislikes, opt => opt.MapFrom(a => a.Likes.Where(l => l.IsLike == false).Count()));
        }
    }
}
