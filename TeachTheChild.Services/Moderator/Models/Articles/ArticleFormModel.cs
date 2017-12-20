namespace TeachTheChild.Services.Moderator.Models.Articles
{
    using TeachTheChild.Common.Mappings;
    using TeachTheChild.Data.Models.Articles;

    public class ArticleFormModel : IMapTo<Article>, IMapFrom<Article>
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string UserId { get; set; }

        public int LanguageId { get; set; }
    }
}
