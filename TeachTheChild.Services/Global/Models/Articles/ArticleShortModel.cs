namespace TeachTheChild.Services.Global.Models.Articles
{
    using AutoMapper;
    using TeachTheChild.Common.Mappings;
    using TeachTheChild.Data.Models.Articles;

    public class ArticleShortModel : IMapFrom<Article>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string ShortContent { get; set; }

        public void ApplyCustomMappings(Profile profile)
        {
            profile.CreateMap<Article, ArticleShortModel>()
                .ForMember(a => a.ShortContent, opt => opt.MapFrom(a => a.Content.Substring(0, 750)));
        }
    }
}
